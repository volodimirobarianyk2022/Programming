using System;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private Func<T, T, TR> operation;
    private T operand1;
    private T operand2;
    private string functionName;

    public TR Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2, string functionName)
    {
        this.operation = operation;
        this.operand1 = operand1;
        this.operand2 = operand2;
        this.functionName = functionName;
    }

    public void StartEvaluation()
    {
        Task.Run(() =>
        {
            Console.WriteLine("Evaluation started for " + functionName + "...");
            Result = operation(operand1, operand2);
            Console.WriteLine("Evaluation completed for " + functionName + "!");
        });
    }

    public void Evaluate()
    {
        Console.WriteLine("Evaluation started for " + functionName + "...");
        Result = operation(operand1, operand2);
        Console.WriteLine("Evaluation completed for " + functionName + "!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Func<int, int, int> add = (a, b) => a + b;
        int operand1 = 10;
        int operand2 = 20;

        Func<int, int, int> multiply = (a, b) => a * b;
        int operand3 = 5;
        int operand4 = 6;

        ParallelUtils<int, int> parallelUtilsAdd = new ParallelUtils<int, int>(add, operand1, operand2, "Addition");
        ParallelUtils<int, int> parallelUtilsMultiply = new ParallelUtils<int, int>(multiply, operand3, operand4, "Multiplication");

        parallelUtilsAdd.StartEvaluation();
        parallelUtilsMultiply.StartEvaluation();

        parallelUtilsAdd.Evaluate();
        parallelUtilsMultiply.Evaluate();

        Console.WriteLine("Result (Addition): " + parallelUtilsAdd.Result);
        Console.WriteLine("Result (Multiplication): " + parallelUtilsMultiply.Result);
    }
}
