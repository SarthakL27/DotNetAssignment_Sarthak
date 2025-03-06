using Day6_1Assignment.Model;

namespace Day6_1Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name");
            string name = Convert.ToString(Console.ReadLine());
            Bank bank = new Bank();
            bank.AddToken(name);
            Console.WriteLine(bank.CheckNext());


            Console.WriteLine("Please enter your name:");
            string name2 = Convert.ToString(Console.ReadLine());
            bank.AddToken(name2);
            Console.WriteLine(bank.CheckNext());
        }
    }
}
