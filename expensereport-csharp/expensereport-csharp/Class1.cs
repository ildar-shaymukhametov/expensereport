using System;
using System.Collections.Generic;
using System.Linq;

namespace expensereport_csharp
{
    public abstract class Expense
    {
        public abstract string name { get; }
        public virtual bool IsMeal { get; }

        public int amount;

        public virtual string GetMarker()
        {
            return " ";
        }
    }

    public class DinnerExpense : Expense
    {
        public override string name => "Dinner";
        public override bool IsMeal => true;

        public override string GetMarker()
        {
            return amount > 5000 ? "X" : base.GetMarker();
        }
    }

    public class BreakfastExpense : Expense
    {
        public override string name => "Breakfast";
        public override bool IsMeal => true;

        public override string GetMarker()
        {
            return amount > 1000 ? "X" : base.GetMarker();
        }
    }

    public class CarRentalExpense : Expense
    {
        public override string name => "CarRental";
    }
    
    public class Expenses : List<Expense>
    {
        public Expenses(List<Expense> expenses) : base(expenses) {}
        
        public int CalculateMealExpenses()
        {
            return this.Where(x => x.IsMeal).Sum(x => x.amount);
        }

        public int CalculateTotal()
        {
            return this.Sum(x => x.amount);
        }
    }

    public class ExpenseReport
    {
        public void PrintReport(Expenses expenses)
        {
            PrintHeader();
            PrintBody(expenses);
            PrintFooter(expenses);
        }

        private static void PrintHeader()
        {
            Console.WriteLine("Expenses " + DateTime.Now);
        }

        private static void PrintBody(Expenses expenses)
        {
            foreach (Expense expense in expenses)
            {
                Console.WriteLine(expense.name + "\t" + expense.amount + "\t" + expense.GetMarker());
            }
        }

        private static void PrintFooter(Expenses expenses)
        {
            Console.WriteLine("Meal expenses: " + expenses.CalculateMealExpenses());
            Console.WriteLine("Total expenses: " + expenses.CalculateTotal());
        }
    }
}