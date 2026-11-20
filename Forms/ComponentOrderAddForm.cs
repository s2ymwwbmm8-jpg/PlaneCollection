namespace ConfectioneryFactory.Forms;

public class ComponentOrderAddForm : EditFormBase
{
    private readonly ComboBox _supplierBox = new() { DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Name" };
    private readonly ComboBox _componentBox = new() { DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Name" };
    private readonly NumericUpDown _quantityBox = new() { DecimalPlaces = 2, Maximum = 1_000_000 };
    private readonly DateTimePicker _dateBox = new() { Format = DateTimePickerFormat.Short };

    public ComponentOrder? Result { get; private set; }

    public ComponentOrderAddForm(ISupplierRepository suppliers, IComponentRepository components)
        : base("New component order")
    {
        _supplierBox.DataSource = suppliers.GetAll().ToList();
        _supplierBox.SelectedIndex = -1;
        _componentBox.DataSource = components.GetAll().ToList();
        _componentBox.SelectedIndex = -1;

        AddField("Supplier:", _supplierBox);
        AddField("Component:", _componentBox);
        AddField("Quantity:", _quantityBox);
        AddField("Date:", _dateBox);
    }

    protected override void Save()
    {
        if (_supplierBox.SelectedItem is not Supplier supplier)
        {
            throw new ValidationException("Supplier must be selected.");
        }

        if (_componentBox.SelectedItem is not Component component)
        {
            throw new ValidationException("Component must be selected.");
        }

        Result = ComponentOrder.Create(supplier, component, _quantityBox.Value, _dateBox.Value.Date);
    }
}
