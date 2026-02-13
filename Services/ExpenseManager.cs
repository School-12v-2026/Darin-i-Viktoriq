// ===================== Person A (Backend) Notes =====================
// TODO (Person A):
// 1) Ensure file format and error handling are robust (bad lines, missing file, etc.)
// 2) Expand statistics if needed (count, min, etc.) or move stats/sorting to separate services.
// 3) Make sure sorting options are present and that after sorting you can show the expenses.
// 4) Add category validation to enforce allowed categories if your teacher requires it.
// ====================================================================

// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

using PersonalBudgetTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonalBudgetTracker.Services
{
    public class ExpenseManager
    {
        private List<Expense> expenses = new List<Expense>();
        private FileStorage storage = new FileStorage();

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
            Save();
        }

        public List<Expense> GetAll() => expenses;

        public void DeleteExpense(int index)
        {
            if (index >= 0 && index < expenses.Count)
            {
                expenses.RemoveAt(index);
                Save();
            }
        }

        public double GetTotal() => expenses.Sum(e => e.Amount);

        public double GetMax() => expenses.Any() ? expenses.Max(e => e.Amount) : 0;

        public double GetAverage() => expenses.Any() ? expenses.Average(e => e.Amount) : 0;

        public Dictionary<string, double> GetByCategory()
        {
            return expenses
                .GroupBy(e => e.Category)
                .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));
        }

        public void SortByAmount() => expenses = expenses.OrderBy(e => e.Amount).ToList();

        public void SortByDate() => expenses = expenses.OrderBy(e => e.Date).ToList();

        public void SortByCategory() => expenses = expenses.OrderBy(e => e.Category).ToList();

        public void Load() => expenses = storage.Load();

        public void Save() => storage.Save(expenses);
    }
}
