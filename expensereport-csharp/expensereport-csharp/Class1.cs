using System;
using System.Collections.Generic;

namespace expensereport_csharp
{
    public enum ExpenseType
    {
        DINNER, BREAKFAST, CAR_RENTAL
    }

    public class Expense
    {
        public ExpenseType type;
        public int amount;
    }

    public class ExpenseReport
    {
        public void PrintReport(List<Expense> expenses)
        {
            int total = 0;
            int mealExpenses = 0;

            Console.WriteLine("Expenses " + DateTime.Now);
            
            foreach (Expense expense in expenses)
            {
                if (expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST)
                {
                    mealExpenses += expense.amount;
                }

                var expenseName = GetExpanseName(expense);
                var mealOverExpensesMarker = GetMarker(expense);

                Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + mealOverExpensesMarker);

                total += expense.amount;
            }

            Console.WriteLine("Meal expenses: " + mealExpenses);
            Console.WriteLine("Total expenses: " + total);
        }

        private static string GetMarker(Expense expense)
        {
            return expense.type == ExpenseType.DINNER && expense.amount > 5000 || expense.type == ExpenseType.BREAKFAST && expense.amount > 1000 ? "X": " ";
        }

        private static string GetExpanseName(Expense expense)
        {
            switch (expense.type)
            {
                case ExpenseType.DINNER:
                    return "Dinner";
                case ExpenseType.BREAKFAST:
                    return "Breakfast";
                case ExpenseType.CAR_RENTAL:
                    return "Car Rental";
                default:
                    return string.Empty;
            }
        }
    }
}