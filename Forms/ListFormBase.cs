namespace ConfectioneryFactory.Forms;

public abstract class ListFormBase : Form
{
    private readonly FlowLayoutPanel _buttonPanel = new()
    {
        Dock = DockStyle.Bottom,
        Height = 45,
        Padding = new Padding(5)
    };

    protected DataGridView Grid { get; } = new()
    {
        Dock = DockStyle.Fill,
        ReadOnly = true,
        AllowUserToAddRows = false,
        AllowUserToDeleteRows = false,
        MultiSelect = false,
        RowHeadersVisible = false,
        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    };

    protected int? SelectedId => Grid.CurrentRow?.Cells["Id"].Value as int?;

    protected ListFormBase(string title)
    {
        Text = title;
        Size = new Size(720, 450);
        StartPosition = FormStartPosition.CenterParent;

        Controls.Add(Grid);
        Controls.Add(_buttonPanel);

        AddButton("Add", (_, _) => OnAdd());
    }

    protected abstract void ReloadData();

    protected abstract void OnAdd();

    protected void AddButton(string text, EventHandler handler)
    {
        var button = new Button { Text = text, AutoSize = true };
        button.Click += handler;
        _buttonPanel.Controls.Add(button);
    }

    protected bool Confirm(string message) =>
        MessageBox.Show(this, message, Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        ReloadData();
    }
}
