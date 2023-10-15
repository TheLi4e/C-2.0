using C_2._0;

internal class Program
{
   
    private static void Main(string[] args)
    {

        const int WINDOW_HEGHT = 11;
        const int WINDOW_WIDTH = 120;
        
        GUI.DrawWindow(0, 0, WINDOW_WIDTH, WINDOW_HEGHT);

        var man = new Man("Alesha", "Korobov", Gender.male, DateTime.Now);
        var woman = new Woman("Ksenia", "Alehina", Gender.female, DateTime.Now);
        
        woman.AddHusband(man);
        man.AddWife(woman);
        
        Console.SetCursorPosition(2, 1);
        Console.WriteLine(woman.PrintHusband());
        Console.SetCursorPosition(2, 6);
        Console.WriteLine(man.PrintWife());
    }
}