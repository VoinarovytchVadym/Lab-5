using HTML.Nodes;

namespace HTML.Commands;

public class ChangeAttributeCommand(LightElementNode node, string attributeName, string newValue)
    : ICommand
{
    private readonly string _oldValue = node.GetAttributeValue(attributeName);

    public void Execute()
    {
        node.SetAttributeValue(attributeName, newValue);
    }

    public void Undo()
    {
        node.SetAttributeValue(attributeName, _oldValue);
    }
}