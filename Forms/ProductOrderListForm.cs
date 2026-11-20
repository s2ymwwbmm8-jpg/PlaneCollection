namespace ConfectioneryFactory.Forms;

public class ProductOrderListForm : ListFormBase
{
    private readonly IProductOrderRepository _orders;
    private readonly IProductRepository _products;
    private readonly Func<ProductOrderAddForm> _addFormFactory;

    public ProductOrderListForm(
        IProductOrderRepository orders,
        IProductRepository products,
        Func<ProductOrderAddForm> addFormFactory) : base("Product orders")
    {
        _orders = orders;
        _products = products;
        _addFormFactory = addFormFactory;
    }

    protected override void ReloadData()
    {
        var productNames = _products.GetAll().ToDictionary(product => product.Id, product => product.Name);

        Grid.DataSource = _orders.GetAll()
            .Select(order => new
            {
                order.Id,
                Product = productNames.GetValueOrDefault(order.ProductId, "-"),
                order.Quantity,
                Date = order.OrderDate.ToShortDateString(),
                order.Amount
            })
            .ToList();

        Grid.Columns["Amount"]!.DefaultCellStyle.Format = "N2";
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
