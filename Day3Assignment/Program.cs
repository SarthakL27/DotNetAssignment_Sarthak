namespace Day3Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question1

            Console.WriteLine("enter the card id");
            int CarId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter brand of the car");
            String brand = Console.ReadLine();

            Console.WriteLine("enter the model of car");
            String model = Console.ReadLine();

            Console.WriteLine("enter the year for the car");
            String ddtt = Console.ReadLine();

            Console.WriteLine("enter the price of the car");
            int price = Convert.ToInt32(Console.ReadLine());

            Car cr = new Car();
            cr.setCarDetails(CarId, brand, model, ddtt, price);
            cr.getDetails();


            Car cr2 = new Car(CarId, brand, model, ddtt, price);

            #endregion
        }
    }
}
