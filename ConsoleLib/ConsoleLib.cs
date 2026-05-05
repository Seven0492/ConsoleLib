namespace ConsoleLib;

public static class Cslib
{
    // Constants
    const string DEFAULT_PREFIX     = " ==> ";
    const ConsoleColor COLOR_BASE   = ConsoleColor.Gray;
    const ConsoleColor COLOR_INPUT  = ConsoleColor.Green;
    const ConsoleColor COLOR_PREFIX = ConsoleColor.White;
    const ConsoleColor COLOR_FLASHY = ConsoleColor.Cyan;
    
    // Methods
    #region DisplayText

    /// <summary>
    /// Displays a header in the console
    /// </summary>
    /// <param name="title">The title of the header</param>
    /// <param name="separatorChar">The character used to separate the header from ordinary text</param>
    /// <param name="separatorCharCount">The nbr of characters of the separators</param>
    /// <param name="color">The color of the header</param>
    public static void DisplayHeader(
        string title,
        char separatorChar = '*',
        int? separatorCharCount = null,
        ConsoleColor color = COLOR_FLASHY
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
        Console.WriteLine( title.PadLeft( ((int)separatorCharCount - title.Length) / 2, ' ' ) );
        Console.WriteLine( separator + Environment.NewLine );

        Console.ForegroundColor = COLOR_BASE;
    }

    /// <summary>
    /// Displays a list of string elements in the console
    /// </summary>
    /// <param name="list">The list of string elements</param>
    /// <param name="indexing">Whether to index list elements</param>
    public static void DisplayList(IReadOnlyList<string> list, bool indexing = false)
    {
        switch (indexing)
        {
            // Display with index
            case true:
                // Avoid ArgumentOutOfRangeException
                if (list.Count is 0)
                {
                    Console.WriteLine();
                    return;
                };
                
                foreach (int index in Enumerable.Range(0, list.Count))
                {
                    Console.WriteLine( $"{index + 1}. {list[index]}" );
                }
                
                break;
            // Display without index
            case false:
                foreach (string entry in list)
                {
                    Console.WriteLine(entry);
                }
                
                break;
        }
        
        // Add following empty line
        Console.WriteLine();
    }

    #endregion

    #region ReadText

    /// <summary>
    /// Reads a line of text in the console
    /// </summary>
    /// <param name="prefix">A string shown before user input</param>
    /// <returns>User input</returns>
    public static string ReadText(string prefix = DEFAULT_PREFIX)
    {
        // Variable
        string? entry;

        // Display prefix
        Console.ForegroundColor = COLOR_PREFIX;
        Console.Write(prefix);

        // Get user input
        Console.ForegroundColor = COLOR_INPUT;

        if ((entry = Console.ReadLine()) is null)
        {
            return "";
        }

        Console.ForegroundColor = COLOR_BASE;

        // Return user input
        return entry;
    }

    /// <summary>
    /// Reads a line of text in the console
    /// </summary>
    /// <param name="textBeforePrefix"></param>
    /// <param name="prefix">A string shown before user input</param>
    /// <returns>User input</returns>
    public static string ReadText(string textBeforePrefix, string prefix = DEFAULT_PREFIX)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reads a limited amount of characters in the console
    /// </summary>
    /// <param name="charCount">The amount of characters to read</param>
    /// <param name="prefix">A string shown before user input</param>
    /// <returns>A string of the characters read</returns>
    public static string ReadTextLimited(uint charCount, bool newlineAfterRead = false, string prefix = DEFAULT_PREFIX)
    {
        // Variables
        List<char> input = new();
        int index = 0;

        // Show prefix
        Console.ForegroundColor = COLOR_PREFIX;
        Console.Write(prefix);
        Console.ForegroundColor = COLOR_INPUT;

        while (index < charCount)
        {
            input.Add( Console.ReadKey().KeyChar );

            index++;
        }

        Console.ForegroundColor = COLOR_BASE;

        if (newlineAfterRead) Console.WriteLine();

        return new string( input.ToArray() );
    }

    #endregion

    #region ReadDouble



    #endregion

    #region ReadInt

    public static int ReadIntWithinBounds(
        int lowerBound, int upperBound,
        string prefix = DEFAULT_PREFIX, string errorMessage = "Erreur : choix entier invalide.")
    {
        // Variable
        string input;
        int number = lowerBound - 1;

        bool success;

        do
        {
            input = ReadText(prefix);

            success = int.TryParse(input, out number);
            success = success && number <= upperBound && number >= lowerBound;

            if (!success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = COLOR_BASE;
            }
        } while (!success);

        return number;
    }

    #endregion

    #region ReadBool

    /// <summary>
    /// Reads a boolean from the console in a case insensitive way
    /// </summary>
    /// <param name="charTrue">The character representing the boolean true</param>
    /// <param name="charFalse">The character representing the boolean false</param>
    /// <param name="prefix">A string shown before user input</param>
    /// <returns>The read boolean</returns>
    public static bool ReadBool(char charTrue, char charFalse, bool falseByDefault = true, string prefix = DEFAULT_PREFIX)
    {
        // Variables
        string input;
        bool result = falseByDefault ? false : true;

        // Read the boolean
        input = ReadTextLimited(1, true, prefix).ToLower();

        // Interpret according to the falseByDefault parameter
        if (falseByDefault)
            if (input == charTrue.ToString().ToLower()) result = true;
        else
            if (input == charFalse.ToString().ToLower())
                result = false;

        return result;
    }

    #endregion
}