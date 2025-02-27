namespace Day2Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region  1st question
            Console.WriteLine("enter the basic salary");
            double basicSal = Convert.ToDouble(Console.ReadLine());

            double TaxDeduction = basicSal * 0.10;

            Console.WriteLine("Enter the performance rating");
            int rating = Convert.ToInt32(Console.ReadLine());

            double bonus = 0;
            if (rating >= 8)
            {
                bonus = basicSal * 0.20;
            }
            if (rating >= 5 && rating < 8)
            {
                bonus = basicSal * 10;
            }
            else
            {
                Console.WriteLine("no bonus");
            }

            double totalsal = basicSal - TaxDeduction + bonus;
            Console.WriteLine("total salary=" + totalsal);
            #endregion

            #region 2nd question
            while (true)
            {
                Console.WriteLine("this is a train ticket booking app");
                Console.WriteLine("these are the available ticket types");
                Console.WriteLine("1.General - 200 INR");
                Console.WriteLine("2.Ac - 1000 INR");
                Console.WriteLine("3.Sleeper - 500 INR");


                Console.WriteLine("Enter the ticket type 1.for general , 2.for AC , 3.for Sleeper , 4.for exit ");

                int chooseticket = Convert.ToInt32(Console.ReadLine());

                if (chooseticket == 4)
                {
                    Console.WriteLine("goodbye thankyou!");
                    break;
                }

                string ticketType = "";

                int price = 0;

                switch (chooseticket)
                {
                    case 1:
                        ticketType = "General";
                        price = 200;
                        break;
                    case 2:
                        ticketType = "AC";
                        price = 1000;
                        break;
                    case 3:
                        ticketType = "Sleeper";
                        price = 500;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a valid number b/w 1-3.");
                        continue;
                }


                Console.Write($"Enter the number of {ticketType} tickets you want: ");
                int Ticketsno = Convert.ToInt32(Console.ReadLine());

                int totalCost = price * Ticketsno;

                Console.WriteLine($"Total cost for {Ticketsno} {ticketType} tickets: {totalCost} INR");
            }
            #endregion

            #region 3rd question
            string userId1 = "111";
            double walletBalance1 = 150.50;

            string userId2 = "112";
            double walletBalance2 = 200.75;

            string userId3 = "113";
            double walletBalance3 = 50.00;

            int enteredUserId;
            bool flag = false;

            while (!flag)
            {
                Console.Write("Enter your User ID: ");
                enteredUserId = Convert.ToInt32(Console.ReadLine());
                
                switch (enteredUserId)
                {
                    case 111:
                        Console.WriteLine($"Wallet balance for {userId1}: ${walletBalance1:F2}");
                        flag = true;
                        break;

                    case 112:
                        Console.WriteLine($"Wallet balance for {userId2}: ${walletBalance2:F2}");
                        flag = true;
                        break;

                    case 113:
                        Console.WriteLine($"Wallet balance for {userId3}: ${walletBalance3:F2}");
                        flag = true;
                        break;

                    default:
                        // If the entered ID is incorrect, prompt again
                        Console.WriteLine("Invalid User ID. Please try again.");
                        break;

                        #endregion
                }
            }
        }

    }
}
        
