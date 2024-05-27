using HTML.Nodes;

namespace HTML.Visitor;

public class ClassSearchVisitor(string targetClass) : IElementVisitor
{
    private readonly List<LightElementNode> _foundElements = [];

    public void VisitElement(LightElementNode element)
    {
        if (element.Classes.Contains(targetClass))
        {
            _foundElements.Add(element);
        }
    }

    public List<LightElementNode> GetFoundElements()
    {
        return _foundElements;
    }
}
