// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

namespace PersonalBudgetTracker.UI
{
    public static class InputHelper
    {
        public static double ReadDouble(string message)
        {
            double value;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid number. Try again: ");
            }
            return value;
        }

        public static int ReadInt(string message)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid number. Try again: ");
            }
            return value;
        }

        public static string ReadString(string message)
        {
            Console.Write(message);
            string? input;
            while (string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                Console.Write("Invalid input. Try again: ");
            }
            return input;
        }

        public static DateTime ReadDate(string message)
        {
            DateTime value;
            Console.Write(message);
            while (!DateTime.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid date. Try again: ");
            }
            return value;
        }
    }
}
