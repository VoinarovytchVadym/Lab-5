using HTML.Nodes;

namespace HTML.States;

public class NormalState : IElementState
{
    public void HandleClick(LightElementNode element)
    {
        Console.WriteLine("Object was clicked");
    }

    public void HandleHover(LightElementNode element)
    {
        Console.WriteLine("You hovered an object");

    }
}