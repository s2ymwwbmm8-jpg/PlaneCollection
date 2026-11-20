namespace ConfectioneryFactory.Forms;

public class ComponentEditForm : EditFormBase
{
    private readonly Component? _component;
    private readonly TextBox _nameBox = new();
    private readonly ComboBox _unitBox = new()
    {
        DropDownStyle = ComboBoxStyle.DropDownList,
        DataSource = Enum.GetValues<UnitOfMeasure>()
    };

    public Component? Result { get; private set; }

    public ComponentEditForm(Component? component = null)
        : base(component is null ? "New component" : "Edit component")
    {
        _component = component;

        AddField("Name:", _nameBox);
        AddField("Unit:", _unitBox);

        if (component is not null)
        {
            _nameBox.Text = component.Name;
            _unitBox.SelectedItem = component.Unit;
        }
    }

    protected override void Save()
    {
        var unit = (UnitOfMeasure)_unitBox.SelectedItem!;

        if (_component is null)
        {
            Result = Component.Create(_nameBox.Text, unit);
            return;
        }

        _component.Update(_nameBox.Text, unit);
        Result = _component;
    }
}
