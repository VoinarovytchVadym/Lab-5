using HTML.Nodes;

namespace HTML.Comands;

public class ChangeAttributeCommand(LightElementNode node, string attributeName, string newValue)
    : ICommand
{
    private readonly string oldValue = node.GetAttributeValue(attributeName);

    public void Execute()
    {
        node.SetAttributeValue(attributeName, newValue);
    }

    public void Undo()
    {
        node.SetAttributeValue(attributeName, oldValue);
    }
}