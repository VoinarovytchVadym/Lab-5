using HTML.Comands;
using HTML.Iterators;
using HTML.Nodes;

namespace HTML;

internal abstract class Program
{
    private static void Main()
    {
        // Початкові значення атрибутів
        LightElementNode node = new LightElementNode("button", "block", "selfClosing", [], []);
       
        Console.WriteLine(node.OuterHTML);

        // Створення команди для зміни атрибута
        ICommand changeAttributeCommand = new ChangeAttributeCommand(node, "TagName", "label");
        changeAttributeCommand.Execute();
        Console.WriteLine(node.OuterHTML);
        
        changeAttributeCommand.Undo();
        Console.WriteLine(node.OuterHTML);
    }
}