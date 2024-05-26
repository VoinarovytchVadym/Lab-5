using HTML.Nodes;

namespace HTML.Iterators;

public class DepthFirstIterator : IIterator
{
    private Stack<LightNode> stack = new Stack<LightNode>();

    public DepthFirstIterator(LightNode root)
    {
        stack.Push(root);
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }

    public LightNode Next()
    {
        if (HasNext())
        {
            LightNode node = stack.Pop();
            if (node is LightElementNode elementNode)
            {
                foreach (var child in elementNode.Childes)
                {
                    stack.Push(child);
                }
            }
            return node;
        }
        throw new InvalidOperationException("No more elements");
    }
}