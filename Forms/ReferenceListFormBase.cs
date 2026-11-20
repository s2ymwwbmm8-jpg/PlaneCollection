namespace ConfectioneryFactory.Forms;

public abstract class ReferenceListFormBase : ListFormBase
{
    protected ReferenceListFormBase(string title) : base(title)
    {
        AddButton("Edit", (_, _) => OnEdit());
        AddButton("Delete", (_, _) => OnDelete());
    }

    protected abstract void OnEdit();

    protected abstract void OnDelete();
}
