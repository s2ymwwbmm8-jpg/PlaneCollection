namespace ConfectioneryFactory.Forms;

public abstract class EditFormBase : Form
{
    private readonly TableLayoutPanel _fields = new()
    {
        Dock = DockStyle.Top,
        AutoSize = true,
        ColumnCount = 2,
        Padding = new Padding(10)
    };

    protected EditFormBase(string title)
    {
        Text = title;
        ClientSize = new Size(420, 250);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;

        _fields.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        _fields.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

        var okButton = new Button { Text = "OK", AutoSize = true };
        var cancelButton = new Button { Text = "Cancel", AutoSize = true, DialogResult = DialogResult.Cancel };
        okButton.Click += OnOkClick;

        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Bottom,
            FlowDirection = FlowDirection.RightToLeft,
            Height = 45,
            Padding = new Padding(5)
        };
        buttonPanel.Controls.Add(cancelButton);
        buttonPanel.Controls.Add(okButton);

        AcceptButton = okButton;
        CancelButton = cancelButton;

        Controls.Add(_fields);
        Controls.Add(buttonPanel);
    }

    protected abstract void Save();

    protected void AddField(string caption, Control control)
    {
        var row = _fields.RowCount++;
        _fields.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var label = new Label
        {
            Text = caption,
            AutoSize = true,
            Anchor = AnchorStyles.Left,
            Margin = new Padding(3, 8, 10, 3)
        };
        control.Anchor = AnchorStyles.Left | AnchorStyles.Right;

        _fields.Controls.Add(label, 0, row);
        _fields.Controls.Add(control, 1, row);
    }

    private void OnOkClick(object? sender, EventArgs e)
    {
        try
        {
            Save();
            DialogResult = DialogResult.OK;
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
