namespace ConfectioneryFactory.Forms;

public class SupplierListForm : ReferenceListFormBase
{
    private readonly ISupplierRepository _repository;

    public SupplierListForm(ISupplierRepository repository) : base("Suppliers")
    {
        _repository = repository;
    }

    protected override void ReloadData()
    {
        Grid.DataSource = _repository.GetAll()
            .Select(item => new { item.Id, item.Name, item.Phone })
            .ToList();
    }

    protected override void OnAdd()
    {
        using var form = new SupplierEditForm();
        if (form.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        _repository.Add(form.Result!);
        ReloadData();
    }

    protected override void OnEdit()
    {
        if (SelectedId is not int id || _repository.GetById(id) is not { } item)
        {
            return;
        }

        using var form = new SupplierEditForm(item);
        if (form.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        _repository.Update(item);
        ReloadData();
    }

    protected override void OnDelete()
    {
        if (SelectedId is not int id || !Confirm("Delete the selected record?"))
        {
            return;
        }

        _repository.Delete(id);
        ReloadData();
    }
}
