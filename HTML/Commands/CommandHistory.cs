namespace HTML.Commands;

public class CommandHistory
{
    private readonly Stack<ICommand> _executedCommands = new Stack<ICommand>();
    private readonly Stack<ICommand> _undoneCommands = new Stack<ICommand>();

    public void AddCommand(ICommand command)
    {
        _executedCommands.Push(command);
        _undoneCommands.Clear();
    }

    public void UndoLastCommand()
    {
        if (_executedCommands.Count > 0)
        {
            ICommand lastCommand = _executedCommands.Pop();
            lastCommand.Undo();
            _undoneCommands.Push(lastCommand);
        }
    }

    public void RedoLastUndoneCommand()
    {
        if (_undoneCommands.Count > 0)
        {
            ICommand lastUndoneCommand = _undoneCommands.Pop();
            lastUndoneCommand.Execute();
            _executedCommands.Push(lastUndoneCommand);
        }
    }
}

//
// using HTML.Comands;
// using HTML.Iterators;
// using HTML.Nodes;
//
// namespace HTML;
//
// internal abstract class Program
// {
//     private static void Main()
//     {
//         // Початкові значення атрибутів
//         LightElementNode node = new LightElementNode("button", "block", "selfClosing", [], []);
//        
//         Console.WriteLine(node.OuterHTML);
//
//         // Створення команди для зміни атрибута
//         ICommand changeAttributeCommand = new ChangeAttributeCommand(node, "TagName", "label");
//         changeAttributeCommand.Execute();
//         Console.WriteLine(node.OuterHTML);
//         
//         changeAttributeCommand.Undo();
//         Console.WriteLine(node.OuterHTML);
//     }
// }