using System;
using System.Collections.Generic;
using System.Linq;

class FinancialForecaster
{
    static void Main()
    {
        Console.WriteLine("Financial Forecasting Tool");
        Console.WriteLine("==========================");
        
        // Get initial investment value
        double initialValue = GetUserInput("Enter initial investment value: ");
        
        // Get historical growth rates
        int rateCount = (int)GetUserInput("Enter number of historical growth periods: ");
        List<double> growthRates = new List<double>();
        for (int i = 0; i < rateCount; i++)
        {
            growthRates.Add(GetUserInput($"Enter growth rate for period #{i+1} (decimal format): "));
        }
        
        // Get projection period
        int periods = (int)GetUserInput("Enter future projection periods: ");
        
        // Calculate average growth rate
        double avgRate = growthRates.Average();
        Console.WriteLine($"\nUsing average growth rate: {avgRate:P2}");
        
        // Calculate future value
        double futureValue = CalculateFutureValue(initialValue, avgRate, periods);
        
        // Format currency with Rupee symbol
        Console.WriteLine($"\nProjected value after {periods} periods: Rs {futureValue:N2}");
    }

    static double GetUserInput(string prompt)
    {
        double input;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write(prompt);
        }
        return input;
    }

    static double CalculateFutureValue(double currentValue, double growthRate, int remainingPeriods)
    {
        if (remainingPeriods == 0)
            return currentValue;
        
        double nextValue = currentValue * (1 + growthRate);
        return CalculateFutureValue(nextValue, growthRate, remainingPeriods - 1);
    }
}
