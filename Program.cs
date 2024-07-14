using System;
using System.Collections.Generic;
using System.Linq;

public class StatisticsCalculator
{
    public static void Main(string[] args)
    {
        List<double> heights = new List<double>();
        List<double> widths = new List<double>();

        Console.WriteLine("Enter the height values separated by commas:");
        string heightInput = Console.ReadLine();
        heights = heightInput.Split(',').Select(double.Parse).ToList();

        Console.WriteLine("Enter the width values separated by commas:");
        string widthInput = Console.ReadLine();
        widths = widthInput.Split(',').Select(double.Parse).ToList();

        if (heights.Count != widths.Count)
        {
            Console.WriteLine("The number of height values and width values must be the same.");
            return;
        }

        // Print the heights and widths in table form
        Console.WriteLine("\nHeight\tWidth");
        for (int i = 0; i < heights.Count; i++)
        {
            Console.WriteLine($"{heights[i]}\t{widths[i]}");
        }

        List<double> data = new List<double>();
        for (int i = 0; i < heights.Count; i++)
        {
            for (int j = 0; j < widths[i]; j++)
            {
                data.Add(heights[i]);
            }
        }

        double mean = CalculateMean(data);
        double variance = CalculateVariance(data, mean);
        double standardDeviation = Math.Sqrt(variance);
        double meanDeviation = CalculateMeanDeviation(data, mean);

        Console.WriteLine($"\nMean: {mean}");
        Console.WriteLine($"Standard Deviation: {standardDeviation}");
        Console.WriteLine($"Variance: {variance}");
        Console.WriteLine($"Mean Deviation: {meanDeviation}");
    }

    static double CalculateMean(List<double> data)
    {
        return data.Sum() / data.Count;
    }

    static double CalculateVariance(List<double> data, double mean)
    {
        return data.Sum(x => Math.Pow(x - mean, 2)) / data.Count;
    }

    static double CalculateMeanDeviation(List<double> data, double mean)
    {
        return data.Sum(x => Math.Abs(x - mean)) / data.Count;
    }
}
