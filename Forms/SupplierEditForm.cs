namespace ConfectioneryFactory.Forms;

public class SupplierEditForm : EditFormBase
{
    private readonly Supplier? _supplier;
    private readonly TextBox _nameBox = new();
    private readonly TextBox _phoneBox = new();

    public Supplier? Result { get; private set; }

    public SupplierEditForm(Supplier? supplier = null)
        : base(supplier is null ? "New supplier" : "Edit supplier")
    {
        _supplier = supplier;

        AddField("Name:", _nameBox);
        AddField("Phone:", _phoneBox);

        if (supplier is not null)
        {
            _nameBox.Text = supplier.Name;
            _phoneBox.Text = supplier.Phone;
        }
    }

    protected override void Save()
    {
        if (_supplier is null)
        {
            Result = Supplier.Create(_nameBox.Text, _phoneBox.Text);
            return;
        }

        _supplier.Update(_nameBox.Text, _phoneBox.Text);
        Result = _supplier;
    }
}
