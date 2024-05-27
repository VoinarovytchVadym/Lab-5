using HTML.Nodes;

namespace HTML.LifeCycleHooks;

public abstract class LifeCycleHooks
{
    public virtual void OnCreated(LightElementNode node){}
    public virtual void OnClassesApplied(LightElementNode node){}

    public void Run(LightElementNode node)
    {
        OnCreated(node);
        if (node.Classes.Count > 0)
            OnClassesApplied(node);
    }
}