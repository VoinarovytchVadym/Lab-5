namespace HTML.Comands;

public interface ICommand
{
    void Execute(); // Метод для виконання команди
    void Undo();    // Метод для скасування виконаної команди
}