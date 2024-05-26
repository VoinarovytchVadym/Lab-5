using HTML.Nodes;

namespace HTML.States;

public interface IElementState
{
    void HandleClick(LightElementNode element);
    void HandleHover(LightElementNode element);
}
// код для перевірки
// LightElementNode node = new LightElementNode("button", "block", "selfClosing", [], []);
// node.Click();
// node.Hover();
// node.ChangeState(new HoverState());
// node.Click();
// node.Hover();