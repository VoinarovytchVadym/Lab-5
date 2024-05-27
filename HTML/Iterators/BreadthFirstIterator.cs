using HTML.Nodes;

namespace HTML.Iterators;

public class BreadthFirstIterator : IIterator
{
    private readonly Queue<LightNode> _queue = new Queue<LightNode>();

    public BreadthFirstIterator(LightNode root)
    {
        _queue.Enqueue(root);
    }

    public bool HasNext()
    {
        return _queue.Count > 0;
    }

    public LightNode Next()
    {
        if (HasNext())
        {
            LightNode node = _queue.Dequeue();
            if (node is LightElementNode elementNode)
            {
                foreach (var child in elementNode.Childes)
                {
                    _queue.Enqueue(child);
                }
            }
            return node;
        }
        throw new InvalidOperationException("No more elements");
    }
}