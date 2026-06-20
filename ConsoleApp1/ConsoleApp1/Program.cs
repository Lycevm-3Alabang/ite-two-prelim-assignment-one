using System;

class Program
{
    static void Main(string[] args)
    {
        
        Calculator calc = new Calculator();

        while (true)
        {
            Console.Write("Enter first number (or 'exit' to quit): ");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                break;
            }

            double num1 = Convert.ToDouble(input);

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /): ");
            string op = Console.ReadLine();

            
            if (op == "/" && num2 == 0)
            {
                Console.WriteLine("Cannot divide by zero.");
                continue;
            }

  
            double result = calc.Calculate(num1, num2, op);

    
            if (double.IsNaN(result))
            {
                Console.WriteLine("Invalid operator.");
                continue;
            }

            Console.WriteLine("=: " + result);
            Console.WriteLine();
        }

        Console.WriteLine("Program ended.");
    }
}


