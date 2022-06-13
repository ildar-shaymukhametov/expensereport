using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public abstract class Expense
    {
        public abstract string name { get; }
        public ExpenseType type;
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

    public class ExpenseReport
    {
        public void PrintReport(List<Expense> expenses)
        {
            Console.WriteLine("Expenses " + DateTime.Now);

            foreach (Expense expense in expenses)
            {
                Console.WriteLine(expense.name + "\t" + expense.amount + "\t" + expense.GetMarker());
            }

            var mealExpenses = CalculateMealExpenses(expenses);
            Console.WriteLine("Meal expenses: " + mealExpenses);

            int total = CalculateTotal(expenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static int CalculateTotal(List<Expense> expenses)
        {
            int total = 0;
            foreach (Expense expense in expenses)
            {
                total += expense.amount;
            }

            return total;
        }

        private static int CalculateMealExpenses(List<Expense> expenses)
        {
            int result = 0;
            foreach (Expense expense in expenses)
            {
                if (expense is DinnerExpense || expense is BreakfastExpense)
                {
                    result += expense.amount;
                }
            }

            return result;
        }
    }
}