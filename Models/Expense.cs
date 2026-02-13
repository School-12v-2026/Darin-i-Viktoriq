// Project: Console Personal Budget Tracker (team project)
// Note: This file contains explanatory comments for easier presentation.

namespace PersonalBudgetTracker.Models
{
    public class Expense
    {
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        public Expense(double amount, string category, DateTime date)
        {
            Amount = amount;
            Category = category;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Amount}|{Category}|{Date:yyyy-MM-dd}";
        }

        public static Expense FromString(string line)
        {
            var parts = line.Split('|');
            return new Expense(
                double.Parse(parts[0]),
                parts[1],
                DateTime.Parse(parts[2])
            );
        }
    }
}
