using System;

class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        DateTime currentDate = DateTime.Today;
        int experienceYears = currentDate.Year - hiringDate.Year;
        if (currentDate < hiringDate.AddYears(experienceYears))
        {
            experienceYears--;
        }
        return experienceYears;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} years of experience.");
    }
}

class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage)
        : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is a {programmingLanguage} programmer.");
    }
}

class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation)
        : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        string testerType = isAutomation ? "automated" : "manual";
        Console.WriteLine($"{name} is a {testerType} tester.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Developer dev = new Developer("John", new DateTime(2018, 1, 1), "C#");
        dev.ShowInfo();

        Tester tester1 = new Tester("Alice", new DateTime(2017, 5, 1), true);
        tester1.ShowInfo();

        Tester tester2 = new Tester("Bob", new DateTime(2019, 10, 15), false);
        tester2.ShowInfo();
    }
}
