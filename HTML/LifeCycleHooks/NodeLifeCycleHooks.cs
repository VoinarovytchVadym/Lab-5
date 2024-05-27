using HTML.Nodes;

namespace HTML.LifeCycleHooks;

public class NodeLifeCycleHooks : LifeCycleHooks
{
    public override void OnCreated(LightElementNode node)
    {
        Console.WriteLine($"Element {node.TagName} has been created.");
    }

    public override void OnClassesApplied(LightElementNode node)
    {
        Console.WriteLine($"Classes were applied to element {node.TagName}.");
    }
}