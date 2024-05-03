using System;

interface ISwimmable
{
    void Swim();
}

interface IFlyable
{
    int MaxHeight { get; }
    void Fly();
}

interface IRunnable
{
    int MaxSpeed { get; }
    void Run();
}

interface IAnimal
{
    int LifeDuration { get; }
    void Voice();
    void ShowInfo();
}

class Cat : IAnimal, IRunnable
{
    public int MaxSpeed { get; } = 30;
    public int LifeDuration { get; } = 15;

    public void Voice()
    {
        Console.WriteLine("Meow!");
    }

    public void Run()
    {
        Console.WriteLine("I can run up to " + MaxSpeed + " kilometers per hour!");
    }

    public void ShowInfo()
    {
        Console.WriteLine("I am a Cat and I live approximately " + LifeDuration + " years.");
    }
}

class Eagle : IAnimal, IFlyable
{
    public int MaxHeight { get; } = 10000;
    public int LifeDuration { get; } = 25;

    public void Voice()
    {
        Console.WriteLine("No voice!");
    }

    public void Fly()
    {
        Console.WriteLine("I can fly at " + MaxHeight + " meters height!");
    }

    public void ShowInfo()
    {
        Console.WriteLine("I am an Eagle and I live approximately " + LifeDuration + " years.");
    }
}

class Shark : IAnimal, ISwimmable
{
    public int LifeDuration { get; } = 30;

    public void Swim()
    {
        Console.WriteLine("I can swim!");
    }

    public void Voice()
    {
        Console.WriteLine("No voice!");
    }

    public void ShowInfo()
    {
        Console.WriteLine("I am a Shark and I live approximately " + LifeDuration + " years.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cat cat = new Cat();
        cat.ShowInfo();
        cat.Voice();
        cat.Run();

        Console.WriteLine();

        Eagle eagle = new Eagle();
        eagle.ShowInfo();
        eagle.Voice();
        eagle.Fly();

        Console.WriteLine();

        Shark shark = new Shark();
        shark.ShowInfo();
        shark.Voice();
        shark.Swim();
    }
}
