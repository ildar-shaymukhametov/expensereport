using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public class Expense
    {
        public string name { get; }
        public bool IsMeal { get; }
        public bool IsOverLimit { get; }
        public int amount;
        private readonly int limit;

        public Expense(string name, bool isMeal = false, int limit = int.MaxValue)
        {
            this.limit = limit;
            this.IsMeal = isMeal;
            this.name = name;
        }

        public static Expense Dinner => new("Dinner", true, 5000);
        public static Expense Breakfast => new("Breakfast", true, 1000);
        public static Expense Lunch => new("Lunch", true, 2000);
        public static Expense CarRental => new("Car Rental");
    }

    public class ExpenseReport
    {
        public void PrintReport(List<Expense> expenses)
        {
            PrintHeader();
            PrintBody(expenses);
            PrintFooter(expenses);
        }

        private static void PrintHeader()
        {
            Console.WriteLine("Expenses " + DateTime.Now);
        }

        private static void PrintBody(List<Expense> expenses)
        {
            foreach (Expense expense in expenses)
            {
                Console.WriteLine(GenerateRow(expense));
            }
        }

        private static string GenerateRow(Expense expense)
        {
            return expense.name + "\t" + expense.amount + "\t" + GetMarker(expense);
        }

        private static string GetMarker(Expense expense)
        {
            return expense.IsOverLimit ? "X" : " ";
        }

        private static void PrintFooter(List<Expense> expenses)
        {
            Console.WriteLine("Meal expenses: " + CalculateMealExpenses(expenses));
            Console.WriteLine("Total expenses: " + CalculateTotal(expenses));
        }

        private static int CalculateMealExpenses(List<Expense> expenses)
        {
            return expenses.Where(x => x.IsMeal).Sum(x => x.amount);
        }

        private static int CalculateTotal(List<Expense> expenses)
        {
            return expenses.Sum(x => x.amount);
        }
    }
}