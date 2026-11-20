namespace ConfectioneryFactory.Forms;

public class ComponentOrderListForm : ListFormBase
{
    private readonly IComponentOrderRepository _orders;
    private readonly ISupplierRepository _suppliers;
    private readonly IComponentRepository _components;
    private readonly Func<ComponentOrderAddForm> _addFormFactory;

    public ComponentOrderListForm(
        IComponentOrderRepository orders,
        ISupplierRepository suppliers,
        IComponentRepository components,
        Func<ComponentOrderAddForm> addFormFactory) : base("Component orders")
    {
        _orders = orders;
        _suppliers = suppliers;
        _components = components;
        _addFormFactory = addFormFactory;
    }

    protected override void ReloadData()
    {
        var supplierNames = _suppliers.GetAll().ToDictionary(supplier => supplier.Id, supplier => supplier.Name);
        var componentNames = _components.GetAll().ToDictionary(component => component.Id, component => component.Name);

        Grid.DataSource = _orders.GetAll()
            .Select(order => new
            {
                order.Id,
                Supplier = supplierNames.GetValueOrDefault(order.SupplierId, "-"),
                Component = componentNames.GetValueOrDefault(order.ComponentId, "-"),
                order.Quantity,
                Date = order.OrderDate.ToShortDateString()
            })
            .ToList();
    }

    protected override void OnAdd()
    {
        using var form = _addFormFactory();
        if (form.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        _orders.Add(form.Result!);
        ReloadData();
    }
}
