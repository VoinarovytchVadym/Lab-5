using HTML.Nodes;

namespace HTML.Visitor;

public interface IElementVisitor
{
    void VisitElement(LightElementNode element);
}
// LightElementNode div1 = new LightElementNode("div", "block", "normal", ["target"], []);
// LightElementNode div2 = new LightElementNode("div", "block", "normal", ["other"], []);
// LightElementNode div3 = new LightElementNode("div", "block", "normal", ["target"], []);
// LightElementNode div4 = new LightElementNode("div", "block", "normal", ["other"], []);
// LightElementNode div5 = new LightElementNode("div", "block", "normal", ["target", "other"], []);
// LightElementNode html = new LightElementNode("body", "", "normal", 
//     [], 
//     [div1,div2,div3,div4,div5]);
// HTMLDocument document = new HTMLDocument(html);
// ClassSearchVisitor visitor = new ClassSearchVisitor("target");
// document.Accept(visitor);
// List<LightElementNode> elementsWithClass = visitor.GetFoundElements();
// foreach (var item in elementsWithClass)
// {
//     Console.WriteLine(item.OuterHTML);
// }