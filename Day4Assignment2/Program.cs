using Day4Assignment2.Model;

namespace Day4Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("sarthak", 750000);
            Console.WriteLine("employee details");
            emp.DisplayDetails();


            Manager mr = new Manager("shreekanth", 850000, 20000);
            Console.WriteLine("manager details");
            mr.DisplayDetails();
        }
    }
}
