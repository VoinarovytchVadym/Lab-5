namespace HTML.Comands;

public class CommandHistory
{
    private readonly Stack<ICommand> executedCommands = new Stack<ICommand>();
    private readonly Stack<ICommand> undoneCommands = new Stack<ICommand>();

    public void AddCommand(ICommand command)
    {
        executedCommands.Push(command);
        // Під час додавання нової команди очищаємо стек команд, які були скасовані
        undoneCommands.Clear();
    }

    public void UndoLastCommand()
    {
        if (executedCommands.Count > 0)
        {
            ICommand lastCommand = executedCommands.Pop();
            lastCommand.Undo();
            undoneCommands.Push(lastCommand);
        }
    }

    public void RedoLastUndoneCommand()
    {
        if (undoneCommands.Count > 0)
        {
            ICommand lastUndoneCommand = undoneCommands.Pop();
            lastUndoneCommand.Execute();
            executedCommands.Push(lastUndoneCommand);
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