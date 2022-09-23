using System;

class Calculator {
    public static double DoOperation(double num1, double num2, string op) {
        double result = double.NaN;
        switch (op) {
            case "a":
                result = num1 + num2;
                break;
            case "s":
                result = num1 - num2;
                break;
            case "m":
                result = num1 * num2;
                break;
            case "d":
                while (num2 == 0) {
                    Console.WriteLine("Type a non-zero divisor");
                    num2 = Convert.ToDouble(Console.ReadLine());
                }
                result = num1 / num2;
                break;
        }
        return result;
    }
}

class Program {
    static int Main(string[] args) {
        bool endApp = false;
        while (!endApp) {
            string numInput1 = "";
            string numInput2 = "";
            double result = double.NaN;

            Console.Write("Type a number, then press enter ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = double.NaN;
            while (!double.TryParse(numInput1, out cleanNum1)) {
                Console.WriteLine("Invalid input! Type an integer!");
                numInput1 = Console.ReadLine();
            }

            double cleanNum2 = double.NaN;
            Console.Write("Type second number, then press enter ");
            numInput2 = Console.ReadLine();
            while (!double.TryParse(numInput2, out cleanNum2)) {
                Console.WriteLine("Invalid input! Type an integer!");
                numInput2 = Console.ReadLine();
            }

            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");

            string op = Console.ReadLine();
            try {
                result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result)) {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else {
                    Console.WriteLine("Result is: {0:0.##}\n", result);

                }
            }
            catch (Exception e) {
                Console.WriteLine("An exception occurred!\n - Details: " + e.Message);
            }
            Console.WriteLine("----------------\n");

            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: \"");
            if (Console.ReadLine() == "n") {
                endApp = true;
            }
            Console.WriteLine();
        }
        return 0;
    }
}
