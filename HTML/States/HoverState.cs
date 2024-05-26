using HTML.Nodes;

namespace HTML.States;

public class HoverState : IElementState
{
    public void HandleClick(LightElementNode element)
    {
        Console.WriteLine("You hovered an object and clicked");
    }

    public void HandleHover(LightElementNode element)
    {
        Console.WriteLine("Object continues being hovered :)");
    }
}