namespace ConsoleLib;


public static class CsErrorSystem
{
    /// <summary>
    /// A wrapper method to show errors in red
    /// </summary>
    /// <param name="message">The message to show</param>
    public static void ShowError(string message)
    {
        Cslib.DisplayColoredMessage(message, ConsoleColor.Red, Console.BackgroundColor, true);
    }

    public static void ShowCriticalError(string smallErrorDescription, bool inFrench = false)
    {
        if (inFrench)
        {
            Console.WriteLine(
                $"\nAVERTISSEMENT : une erreur critique {smallErrorDescription} mène à l'incapacité " +
                 "de poursuivre les opérations de ce programme.\nFermeture du programme...");
        }
        else
        {
            Console.WriteLine(
                $"\nWARNING : a critical error {smallErrorDescription} prevents the program " +
                 "from pursuing operations.\nProgram exiting...");
        }
    }
}
