namespace ConfectioneryFactory.Forms;

public class ProductEditForm : EditFormBase
{
    private readonly Product? _product;
    private readonly TextBox _nameBox = new();
    private readonly NumericUpDown _priceBox = new() { DecimalPlaces = 2, Maximum = 1_000_000 };
    private readonly CheckedListBox _allergensBox = new() { CheckOnClick = true, Height = 90 };

    public Product? Result { get; private set; }

    public ProductEditForm(Product? product = null)
        : base(product is null ? "New product" : "Edit product")
    {
        _product = product;

        foreach (var allergen in Enum.GetValues<Allergens>().Where(a => a != Allergens.None))
        {
            _allergensBox.Items.Add(allergen);
        }

        AddField("Name:", _nameBox);
        AddField("Price:", _priceBox);
        AddField("Allergens:", _allergensBox);

        if (product is not null)
        {
            _nameBox.Text = product.Name;
            _priceBox.Value = product.Price;

            for (var i = 0; i < _allergensBox.Items.Count; i++)
            {
                _allergensBox.SetItemChecked(i, product.Allergens.HasFlag((Allergens)_allergensBox.Items[i]));
            }
        }
    }

    protected override void Save()
    {
        var allergens = _allergensBox.CheckedItems
            .Cast<Allergens>()
            .Aggregate(Allergens.None, (all, current) => all | current);

        if (_product is null)
        {
            Result = Product.Create(_nameBox.Text, _priceBox.Value, allergens);
            return;
        }

        _product.Update(_nameBox.Text, _priceBox.Value, allergens);
        Result = _product;
    }
}
