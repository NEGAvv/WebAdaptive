using System;
using System.IO;

class Program
{

    static string filePath = "C:\\Users\\hudol\\source\\repos\\WebAdaptive\\WebAdaptive\\files\\Lorem.txt";

    static void Main()
    {
        while (true)
        {
            ShowMenu();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Word count in the text");
        Console.WriteLine("2. Calculate expression");
        Console.WriteLine("3. Exit");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CountWordsInText();
                break;

            case "2":
                PerformMathOperation();
                break;

            case "3":
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Try again");
                break;
        }
    }
     
    // task 1
    static void CountWordsInText( )
    {
        

        Console.WriteLine("Input amount of words:");
        if (int.TryParse(Console.ReadLine(), out int wordCount))
        {
            try
            {
                string fileText = File.ReadAllText(filePath);
                string[] words = fileText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (wordCount <= words.Length)
                {
                    for (int i = 0; i < wordCount; i++)
                    {
                        Console.Write(words[i] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Something wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
    }

    // task 2
    static void PerformMathOperation()
    {
        Console.WriteLine("Input expression:");
        string expression = Console.ReadLine();

        try
        {
            double result = EvaluateMathExpression(expression);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static double EvaluateMathExpression(string expression)
    {
        return Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
    }
}
