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
            Console.WriteLine("Expenses " + DateTime.Now);

            foreach (Expense expense in expenses)
            {
                var expenseName = GetExpanseName(expense);
                var expanseMarker = GetMarker(expense);

                Console.WriteLine(expenseName + "\t" + expense.amount + "\t" + expanseMarker);
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
                if (expense.type == ExpenseType.DINNER || expense.type == ExpenseType.BREAKFAST)
                {
                    result += expense.amount;
                }
            }

            return result;
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