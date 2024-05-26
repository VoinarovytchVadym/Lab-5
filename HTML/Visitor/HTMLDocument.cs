using HTML.Nodes;

namespace HTML.Visitor;

public class HTMLDocument(LightElementNode rootElement)
{
    public void Accept(IElementVisitor visitor)
    {
        Traverse(rootElement, visitor);
    }

    private void Traverse(LightElementNode element, IElementVisitor visitor)
    {
        visitor.VisitElement(element);

        foreach (var child in element.Childes)
        {
            if (child is LightElementNode childElement)
            {
                Traverse(childElement, visitor);
            }
        }
    }
}