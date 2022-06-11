package com.nelkinda.training

import com.nelkinda.training.ExpenseType.BREAKFAST
import com.nelkinda.training.ExpenseType.CAR_RENTAL
import com.nelkinda.training.ExpenseType.DINNER
import com.nelkinda.training.ExpenseType.LUNCH
import org.junit.jupiter.api.AfterEach
import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Test
import java.io.ByteArrayOutputStream
import java.io.PrintStream
import java.util.Date

class ExpenseReportTest {
    private val originalStdout = System.out
    private val interceptedStdout = ByteArrayOutputStream().also {
        System.setOut(PrintStream(it))
    }

    @AfterEach
    fun `restore stdout`() = System.setOut(originalStdout)

    @Test
    fun `characterize printReport`() {
        val now = Date()
        ExpenseReport().printReport(
            listOf(
                Expense(BREAKFAST, 1),
                Expense(BREAKFAST, 1000),
                Expense(BREAKFAST, 1001),
                Expense(DINNER, 2),
                Expense(DINNER, 5000),
                Expense(DINNER, 5001),
                Expense(CAR_RENTAL, 4),
                Expense(LUNCH, 8),
                Expense(LUNCH, 2000),
                Expense(LUNCH, 2001),
            ),
            now,
        )
        val actual = interceptedStdout.toString()
        val expected = "Expenses $now\n" +
                "Breakfast\t1\t \n" +
                "Breakfast\t1000\t \n" +
                "Breakfast\t1001\tX\n" +
                "Dinner\t2\t \n" +
                "Dinner\t5000\t \n" +
                "Dinner\t5001\tX\n" +
                "Car Rental\t4\t \n" +
                "Lunch\t8\t \n" +
                "Lunch\t2000\t \n" +
                "Lunch\t2001\tX\n" +
                "Meal expenses: 16014\n" +
                "Total expenses: 16018\n"
        assertEquals(expected, actual)
    }
}
