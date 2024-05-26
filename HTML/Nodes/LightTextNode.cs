namespace HTML.Nodes;

public class LightTextNode(string text) : LightNode
{
    private string Text { get; } = text;
    public override string OuterHTML => Text;
    public override string InnerHTML => Text;
}