using Day7Assignment1.Model;

namespace Day7Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee(1, "Sakthish J. Nadar", DateTime.Parse("1/16/2025"));
            Employee e2 = new Employee(2, "Om Auti", DateTime.Parse("1/16/2024"));
            Employee e3 = new Employee(3, "Shreekant", DateTime.Parse("1/16/2023"));
            e1.CalculateExperience();
            e2.CalculateExperience();
            e3.CalculateExperience();
        }
    }
}
