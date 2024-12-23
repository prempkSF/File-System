namespace SynCartFS;

/// <summary>
/// Main Class
/// </summary>
class Program
{
    /// <summary>
    /// Main Method to Start the Application
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        FileHandling.Create();
        // Operation.LoadDefaultData();
        FileHandling.ReadCSV();
        Operation.MainMenu();
        FileHandling.WriteCSV();
    }
}