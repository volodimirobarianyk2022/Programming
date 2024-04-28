using System;

delegate double CalcDelegate(double num1, double num2, char operation);

public class CalcProgram
{
    public static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero!");
                    return 0;
                }
                return num1 / num2;
            default:
                Console.WriteLine("Error: Invalid operation!");
                return 0;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CalcDelegate funcCalc = new CalcDelegate(CalcProgram.Calc);

        double result = funcCalc(10, 5, '+');
        Console.WriteLine("10 + 5 = " + result);

        result = funcCalc(10, 5, '-');
        Console.WriteLine("10 - 5 = " + result);

        result = funcCalc(10, 5, '*');
        Console.WriteLine("10 * 5 = " + result);

        result = funcCalc(10, 5, '/');
        Console.WriteLine("10 / 5 = " + result);

        result = funcCalc(10, 0, '/');
        Console.WriteLine("10 / 0 = " + result); 
    }
}
