// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

using PersonalBudgetTracker.Services;
using PersonalBudgetTracker.UI;

namespace PersonalBudgetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            ExpenseManager manager = new ExpenseManager();
            manager.Load();

            Menu menu = new Menu(manager);
            menu.Start();
        }
    }
}
