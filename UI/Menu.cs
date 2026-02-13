// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

using PersonalBudgetTracker.Models;
using PersonalBudgetTracker.Services;

namespace PersonalBudgetTracker.UI
{
    public class Menu
    {
        private ExpenseManager manager;

        public Menu(ExpenseManager manager)
        {
            this.manager = manager;
        }

        public void Start()
        {
            while (true)
            {
                ConsoleStyling.PrintMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddExpense(); break;
                    case "2": ShowExpenses(); break;
                    case "3": DeleteExpense(); break;
                    case "4": ShowStatistics(); break;
                    case "5": SortMenu(); break;
                    case "6": return;
                }
            }
        }

        private void AddExpense()
        {
            double amount = InputHelper.ReadDouble("Amount: ");
            string category = InputHelper.ReadString("Category: ");
            DateTime date = InputHelper.ReadDate("Date (yyyy-mm-dd): ");
            manager.AddExpense(new Expense(amount, category, date));
        }

        private void ShowExpenses()
        {
            var expenses = manager.GetAll();
            for (int i = 0; i < expenses.Count; i++)
                ConsoleStyling.PrintExpense(i, expenses[i]);
        }

        private void DeleteExpense()
        {
            int index = InputHelper.ReadInt("Index to delete: ");
            manager.DeleteExpense(index);
        }

        private void ShowStatistics()
        {
            Console.WriteLine($"Total: {manager.GetTotal()}");
            Console.WriteLine($"Max: {manager.GetMax()}");
            Console.WriteLine($"Average: {manager.GetAverage()}");

            var byCategory = manager.GetByCategory();
            foreach (var item in byCategory)
                Console.WriteLine($"{item.Key}: {item.Value}");
        }

        private void SortMenu()
        {
            Console.WriteLine("1. By Amount");
            Console.WriteLine("2. By Date");
            Console.WriteLine("3. By Category");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": manager.SortByAmount(); break;
                case "2": manager.SortByDate(); break;
                case "3": manager.SortByCategory(); break;
            }
        }
    }
}
