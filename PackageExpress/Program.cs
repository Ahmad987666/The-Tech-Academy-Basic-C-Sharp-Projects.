using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message to the user
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");

        // Ask the user for the package weight
        Console.WriteLine("Please enter the package weight:");

        // Convert user input (string) to a decimal value
        decimal weight = Convert.ToDecimal(Console.ReadLine());

        // Check if the weight exceeds the allowed limit (50)
        if (weight > 50)
        {
            // Display error message if package is too heavy
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            
            // End the program early
            return;
        }

        // Ask the user for the package width
        Console.WriteLine("Please enter the package width:");
        decimal width = Convert.ToDecimal(Console.ReadLine());

        // Ask the user for the package height
        Console.WriteLine("Please enter the package height:");
        decimal height = Convert.ToDecimal(Console.ReadLine());

        // Ask the user for the package length
        Console.WriteLine("Please enter the package length:");
        decimal length = Convert.ToDecimal(Console.ReadLine());

        // Calculate the total dimensions
        decimal dimensionTotal = width + height + length;

        // Check if total dimensions exceed 50
        if (dimensionTotal > 50)
        {
            // Display error message if package is too large
            Console.WriteLine("Package too big to be shipped via Package Express.");
            
            // End the program early
            return;
        }

        // Calculate the quote:
        // Multiply width, height, and length together,
        // then multiply by weight, then divide by 100
        decimal quote = (width * height * length * weight) / 100;

        // Display the result formatted as currency
        Console.WriteLine("Your estimated total for shipping this package is: $" + quote.ToString("0.00"));

        // Display thank you message
        Console.WriteLine("Thank you!");
    }
}