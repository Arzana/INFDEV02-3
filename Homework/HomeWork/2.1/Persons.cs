namespace _2._1
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public interface Person
    {
        /* Person should not be an interface but an abstract base class.
         * Making Person an interface is a possible solution for the problem of reusing code
         * but is not the best way. Making Person an abstract base class will fix the
         * problem of reusing code, result in less typing and have higher performance because
         * the interface dispatcher doesn't need to be called. */

        byte Age { get; }
        string Name { get; }
        string SurName { get; }
    }

    public class Customer : Person
    {
        public byte Age { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public readonly string UserName;
        public decimal Credits { get; private set; }

        private byte[] password;
        private static SHA512 hasher = SHA512.Create();

        public Customer(string userName, string password)
        {
            Age = 0;
            Name = string.Empty;
            SurName = string.Empty;
            UserName = userName;
            Credits = 0;
            this.password = ComputeHash(password);
        }

        public bool TryBuy(string pass, decimal cost)
        {
            if (password != ComputeHash(pass)) return false;
            Credits -= cost;
            return true;
        }

        public void AddCredits(decimal credits) => Credits += credits;

        private static byte[] ComputeHash(string chars) => hasher.ComputeHash(Encoding.UTF8.GetBytes(chars));
    }

    public sealed class Student : Person, IEquatable<Student>
    {
        public byte Age { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public readonly int Id;
        public readonly int EnrollYear;
        public byte Grade { get; private set; }

        public Student(int id, int year)
        {
            Age = 0;
            Name = string.Empty;
            SurName = string.Empty;
            Id = id;
            EnrollYear = year;
            Grade = 0;
        }

        public int YearsInSchool() => DateTime.Now.Year - EnrollYear;
        public void SetGrade(byte newGrade) => Grade = newGrade;
        public bool Equals(Student other) => other.Id == Id;
    }

    public sealed class Teacher : Person, IEquatable<Teacher>
    {
        public byte Age { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public readonly int Id;
        public int Salary { get; private set; }
        public int NumClasses { get; private set; }

        public Teacher(int id, int numClasses)
        {
            Age = 0;
            Name = string.Empty;
            SurName = string.Empty;
            Id = id;
            Salary = 0;
            NumClasses = numClasses;
        }

        public void IncreaseSalary(int addition) => Salary += addition;
        public void DecreaseSalary(int subtraction) => Salary -= subtraction;
        public bool Equals(Teacher other) => other.Id == Id;
    }
}