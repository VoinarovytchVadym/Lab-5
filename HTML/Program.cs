using HTML.Iterators;
using HTML.Nodes;

namespace HTML;

internal abstract class Program
{
    private static void Main()
    {
        // Створюємо HTML-документ
        var rootElement = new LightElementNode("html", "block", "closing", [], []);
        var headElement = new LightElementNode("head", "block", "closing", [], []);
        var bodyElement = new LightElementNode("body", "block", "closing", [], []);
        rootElement.Childes.Add(headElement);
        rootElement.Childes.Add(bodyElement);

        // Створюємо ітератор для перебору в глибину
        IIterator depthIterator = new DepthFirstIterator(rootElement);
        Console.WriteLine("Depth First Traversal:");
        while (depthIterator.HasNext())
        {
            var node = depthIterator.Next();
            Console.WriteLine(node.OuterHTML);
        }

        // Створюємо ітератор для перебору в ширину
        IIterator breadthIterator = new BreadthFirstIterator(rootElement);
        Console.WriteLine("\nBreadth First Traversal:");
        while (breadthIterator.HasNext())
        {
            var node = breadthIterator.Next();
            Console.WriteLine(node.OuterHTML);
        }
    }
}