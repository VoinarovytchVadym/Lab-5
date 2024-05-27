using HTML.Nodes;

namespace HTML.Iterators;

public class DepthFirstIterator : IIterator
{
    private readonly Stack<LightNode> _stack = new Stack<LightNode>();

    public DepthFirstIterator(LightNode root)
    {
        _stack.Push(root);
    }

    public bool HasNext()
    {
        return _stack.Count > 0;
    }

    public LightNode Next()
    {
        if (HasNext())
        {
            LightNode node = _stack.Pop();
            if (node is LightElementNode elementNode)
            {
                foreach (var child in elementNode.Childes)
                {
                    _stack.Push(child);
                }
            }
            return node;
        }
        throw new InvalidOperationException("No more elements");
    }
}