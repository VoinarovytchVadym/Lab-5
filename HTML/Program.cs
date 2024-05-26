using HTML.Comands;
using HTML.Iterators;
using HTML.Nodes;
using HTML.States;

namespace HTML;

internal abstract class Program
{
    private static void Main()
    {
        LightElementNode node = new LightElementNode("button", "block", "selfClosing", [], []);
        node.Click();
        node.Hover();
        node.ChangeState(new HoverState());
        node.Click();
        node.Hover();
    }
}