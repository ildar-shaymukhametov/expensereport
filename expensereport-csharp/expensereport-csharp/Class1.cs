using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public abstract class Expense
    {
        public abstract string name { get; }
        public int amount;

        public virtual string GetMarker()
        {
            return " ";
        }
    }

    public class DinnerExpense : Expense
    {
        public override string name => "Dinner";

        public override string GetMarker()
        {
            return amount > 5000 ? "X" : base.GetMarker();
        }
    }

    public class BreakfastExpense : Expense
    {
        public override string name => "Breakfast";

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
            int result = 0;
            foreach (var expense in this)
            {
                if (expense is DinnerExpense || expense is BreakfastExpense)
                {
                    result += expense.amount;
                }
            }

            return result;
        }

        public int CalculateTotal()
        {
            int total = 0;
            foreach (Expense expense in this)
            {
                total += expense.amount;
            }

            return total;
        }
    }

    public class ExpenseReport
    {
        public void PrintReport(Expenses expenses)
        {
            Console.WriteLine("Expenses " + DateTime.Now);

            foreach (Expense expense in expenses)
            {
                Console.WriteLine(expense.name + "\t" + expense.amount + "\t" + expense.GetMarker());
            }

            var mealExpenses = expenses.CalculateMealExpenses();
            Console.WriteLine("Meal expenses: " + mealExpenses);

            int total = expenses.CalculateTotal();
            Console.WriteLine("Total expenses: " + total);
        }
    }
}