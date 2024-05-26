using HTML.Nodes;

namespace HTML.Iterators;

public interface IIterator
{
    bool HasNext();
    LightNode Next();
}