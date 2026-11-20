namespace ConfectioneryFactory.Forms;

public class ProductOrderAddForm : EditFormBase
{
    private readonly ComboBox _productBox = new() { DropDownStyle = ComboBoxStyle.DropDownList, DisplayMember = "Name" };
    private readonly NumericUpDown _quantityBox = new() { Maximum = 100_000 };
    private readonly DateTimePicker _dateBox = new() { Format = DateTimePickerFormat.Short };
    private readonly Label _amountLabel = new() { Text = "0.00", AutoSize = true };

    public ProductOrder? Result { get; private set; }

    public ProductOrderAddForm(IProductRepository products) : base("New product order")
    {
        _productBox.DataSource = products.GetAll().ToList();
        _productBox.SelectedIndex = -1;

        AddField("Product:", _productBox);
        AddField("Quantity:", _quantityBox);
        AddField("Date:", _dateBox);
        AddField("Amount:", _amountLabel);

        _productBox.SelectedIndexChanged += (_, _) => UpdateAmount();
        _quantityBox.ValueChanged += (_, _) => UpdateAmount();
    }

    protected override void Save()
    {
        if (_productBox.SelectedItem is not Product product)
        {
            throw new ValidationException("Product must be selected.");
        }

        Result = ProductOrder.Create(product, (int)_quantityBox.Value, _dateBox.Value.Date);
    }

    private void UpdateAmount()
    {
        var price = (_productBox.SelectedItem as Product)?.Price ?? 0;
        _amountLabel.Text = (price * _quantityBox.Value).ToString("N2");
    }
}
