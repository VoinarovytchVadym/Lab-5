using HTML.Nodes;

namespace HTML.Visitor;

public class ClassSearchVisitor(string targetClass) : IElementVisitor
{
    private List<LightElementNode> foundElements = [];

    public void VisitElement(LightElementNode element)
    {
        if (element.Classes.Contains(targetClass))
        {
            foundElements.Add(element);
        }
    }

    public List<LightElementNode> GetFoundElements()
    {
        return foundElements;
    }
}
