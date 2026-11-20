namespace ConfectioneryFactory.Forms;

public class MainForm : Form
{
    public MainForm(
        Func<ProductListForm> productListFactory,
        Func<ComponentListForm> componentListFactory,
        Func<SupplierListForm> supplierListFactory,
        Func<ProductOrderListForm> productOrderListFactory,
        Func<ComponentOrderListForm> componentOrderListFactory)
    {
        Text = "Confectionery Factory";
        Size = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;

        var references = new ToolStripMenuItem("References");
        references.DropDownItems.Add("Products", null, (_, _) => OpenDialog(productListFactory));
        references.DropDownItems.Add("Components", null, (_, _) => OpenDialog(componentListFactory));
        references.DropDownItems.Add("Suppliers", null, (_, _) => OpenDialog(supplierListFactory));

        var operations = new ToolStripMenuItem("Operations");
        operations.DropDownItems.Add("Product orders", null, (_, _) => OpenDialog(productOrderListFactory));
        operations.DropDownItems.Add("Component orders", null, (_, _) => OpenDialog(componentOrderListFactory));

        var reports = new ToolStripMenuItem("Reports");

        var menu = new MenuStrip();
        menu.Items.AddRange(new ToolStripItem[] { references, operations, reports });

        MainMenuStrip = menu;
        Controls.Add(menu);
    }

    private void OpenDialog(Func<Form> formFactory)
    {
        using var form = formFactory();
        form.ShowDialog(this);
    }
}
