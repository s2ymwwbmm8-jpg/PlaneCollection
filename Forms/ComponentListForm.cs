namespace ConfectioneryFactory.Forms;

public class ComponentListForm : ReferenceListFormBase
{
    private readonly IComponentRepository _repository;

    public ComponentListForm(IComponentRepository repository) : base("Components")
    {
        _repository = repository;
    }

    protected override void ReloadData()
    {
        Grid.DataSource = _repository.GetAll()
            .Select(item => new { item.Id, item.Name, item.Unit })
            .ToList();
    }

    protected override void OnAdd()
    {
        using var form = new ComponentEditForm();
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

        using var form = new ComponentEditForm(item);
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
