// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

using PersonalBudgetTracker.Models;

namespace PersonalBudgetTracker.UI
{
    public static class ConsoleStyling
    {
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. Show Expenses");
            Console.WriteLine("3. Delete Expense");
            Console.WriteLine("4. Statistics");
            Console.WriteLine("5. Sort");
            Console.WriteLine("6. Exit");
            Console.ResetColor();
        }

        public static void PrintExpense(int index, Expense expense)
        {
            if (expense.Amount > 100)
                Console.ForegroundColor = ConsoleColor.Red;
            else if (expense.Amount < 20)
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{index}. {expense.Amount} | {expense.Category} | {expense.Date:yyyy-MM-dd}");
            Console.ResetColor();
        }
    }
}
