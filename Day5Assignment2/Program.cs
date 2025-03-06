using Day5Assignment2.Model;

namespace Day5Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            Console.WriteLine("Please enter your vehicle type: ");
            Console.WriteLine("1. Two-wheeler");
            Console.WriteLine("2. Four-wheeler");
            Console.WriteLine("3. Commercial");

            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    TwoWheeler v1 = new TwoWheeler(1000, 2000);
                    Console.WriteLine($"your two wheeler insurance is :Rs.{v1.InsuranceCalc()}");
                    break;
                case 2:
                    FourWheeler v2 = new FourWheeler(2000, 3000);
                    Console.WriteLine($"Your Four-wheeler insurance is: Rs. {v2.InsuranceCalc()}");
                    break;
                case 3:
                    Commercial v3 = new Commercial(2000, 4000);
                    Console.WriteLine($"Your Commercial insurance is: Rs. {v3.InsuranceCalc()}");
                    break;
                default:
                    Console.WriteLine("Please enter correct choice");
                    break;
            }
        }
    }
}
