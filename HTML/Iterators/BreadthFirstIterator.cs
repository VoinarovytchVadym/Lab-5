using HTML.Nodes;

namespace HTML.Iterators;

public class BreadthFirstIterator : IIterator
{
    private Queue<LightNode> queue = new Queue<LightNode>();

    public BreadthFirstIterator(LightNode root)
    {
        queue.Enqueue(root);
    }

    public bool HasNext()
    {
        return queue.Count > 0;
    }

    public LightNode Next()
    {
        if (HasNext())
        {
            LightNode node = queue.Dequeue();
            if (node is LightElementNode elementNode)
            {
                foreach (var child in elementNode.Childes)
                {
                    queue.Enqueue(child);
                }
            }
            return node;
        }
        throw new InvalidOperationException("No more elements");
    }
}