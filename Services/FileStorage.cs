// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

using PersonalBudgetTracker.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PersonalBudgetTracker.Services
{
    public class FileStorage
    {
        private string path = "Data/expenses.txt";

        public void Save(List<Expense> expenses)
        {
            Directory.CreateDirectory("Data");
            File.WriteAllLines(path, expenses.Select(e => e.ToString()));
        }

        public List<Expense> Load()
        {
            if (!File.Exists(path))
                return new List<Expense>();

            var lines = File.ReadAllLines(path);
            return lines.Select(line => Expense.FromString(line)).ToList();
        }
    }
}
