using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public abstract class Expense
    {
        public abstract string name { get; }
        public virtual bool IsMeal { get; }
        public virtual bool IsOverLimit { get; }
        public int amount;
    }

    public class DinnerExpense : Expense
    {
        public override string name => "Dinner";
        public override bool IsMeal => true;
        public override bool IsOverLimit => amount > 5000;
    }

    public class BreakfastExpense : Expense
    {
        public override string name => "Breakfast";
        public override bool IsMeal => true;
        public override bool IsOverLimit => amount > 1000;
    }

    public class CarRentalExpense : Expense
    {
        public override string name => "CarRental";
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