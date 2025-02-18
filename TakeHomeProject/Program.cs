// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using TakeHomeProject.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // Provided Case 1
        ExecuteCase("ABCDABAA");

        // Provided Case 2
        ExecuteCase("CCCCCCC");

        // Provided Case 3
        ExecuteCase("ABCD");

        // Custom Cases
        ExecuteCase("CCCCCCCCCCCCCCCCCCCCCCCCCCC");
        ExecuteCase("AAAACCAAAACCAACC");
        ExecuteCase("ABCDE");
        ExecuteCase("AAAAAAAAAA");
    }

    public static void ExecuteCase(string inputString)
    {
        Terminal terminal = new Terminal();
        foreach (var item in inputString)
        {
            terminal.Scan(item.ToString());
        }
        var totalPrice = terminal.Total();
        Console.WriteLine($"Results For {inputString}: {totalPrice}");
    }
}