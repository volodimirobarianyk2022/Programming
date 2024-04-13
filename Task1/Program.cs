using System;

namespace YourNamespace
{
    public class MyAccessModifiers
    {
        private int birthYear;
        protected string personalInfo;
        internal string IdNumber;
        protected internal byte averageMiddleAge = 50;

        public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
        {
            this.birthYear = birthYear;
            this.IdNumber = idNumber;
            this.personalInfo = personalInfo;
            this.Name = "";
            this.NickName = "";
        }

        public int Age => DateTime.Now.Year - birthYear;

        public string? Name { get; set; }

        public string? NickName { get; internal set; }

        public void HasLivedHalfOfLife()
        {
            Console.WriteLine("Half of life has been lived.");
        }

        public static bool operator ==(MyAccessModifiers obj1, MyAccessModifiers obj2)
        {
            return obj1.Name == obj2.Name && obj1.Age == obj2.Age && obj1.personalInfo == obj2.personalInfo;
        }

        public static bool operator !=(MyAccessModifiers obj1, MyAccessModifiers obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            MyAccessModifiers other = (MyAccessModifiers)obj;
            return this.Name == other.Name && this.Age == other.Age && this.personalInfo == other.personalInfo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, personalInfo);
        }

        static void Main(string[] args)
        {
            MyAccessModifiers myObject = new MyAccessModifiers(1990, "123456", "Personal info");

            Console.WriteLine($"Age: {myObject.Age}");
            myObject.Name = "John";
            myObject.NickName = "Johnny";

            Console.WriteLine($"Name: {myObject.Name}, NickName: {myObject.NickName}");

            myObject.HasLivedHalfOfLife();

            MyAccessModifiers anotherObject = new MyAccessModifiers(1990, "123456", "Personal info");
            Console.WriteLine($"Objects are equal: {myObject == anotherObject}");
        }
    }
}
