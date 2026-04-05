namespace ConsoleLib;

public static class ConsoleLib
{
    // Constants
    const ConsoleColor COLOR_BASE   = ConsoleColor.Gray;
    const ConsoleColor COLOR_INPUT  = ConsoleColor.Green;
    const ConsoleColor COLOR_PREFIX = ConsoleColor.White;
    const ConsoleColor FLASHY_COLOR = ConsoleColor.Cyan;
    const bool SHOW_EMPTY_LINE_AFTER_READ = true;
    
    // Methods
    #region DisplayText

    /// <summary>
    /// Displays an header in the console
    /// </summary>
    /// <param name="title">The title of the header</param>
    /// <param name="separatorChar">The character used to separate the header from ordinary text</param>
    /// <param name="separatorCharCount">The nbr of characters of the separators</param>
    /// <param name="color">The color of the header</param>
    public static void DisplayHeader(
        string title,
        char separatorChar = '*',
        int? separatorCharCount = null,
        ConsoleColor color = FLASHY_COLOR
    )
    {
        // Sanitize input parameters
        title = title.ToUpper();

        if (separatorCharCount is < 0 or null)
        {
            separatorCharCount = title.Length + 20;
        }
        
        // Variable
        string separator = "".PadLeft( (int)separatorCharCount, separatorChar );
        
        // Display
        Console.ForegroundColor = color;

        Console.WriteLine( separator );
        Console.WriteLine( title.PadLeft( ((int)separatorCharCount - title.Length) / 2 ) );
        Console.WriteLine( separator + Environment.NewLine );

        Console.ForegroundColor = COLOR_BASE;
    }

    #endregion

    #region ReadText



    #endregion

    #region ReadDouble



    #endregion

    #region ReadInt



    #endregion

    #region ReadBool



    #endregion
}