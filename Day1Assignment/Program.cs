namespace Day1Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region first
            Console.WriteLine("enter your name");
            string name = Console.ReadLine();


            Console.WriteLine("enter your percentages");
            double percentage = Convert.ToDouble(Console.ReadLine());

            #endregion

            #region second que
            int age;
            Console.WriteLine("Enter age:");
            bool checking;
            checking = int.TryParse(Console.ReadLine(), out age);

            if (checking)
            {
                Console.WriteLine("age is valid:" + age);
            }
            else
            {
                Console.WriteLine("age entered in not a valid input format");
            }


            #endregion

            #region third que
            Console.WriteLine("enter your email");
            string email = Console.ReadLine();

            if (email.Length == 0)
            {
                Console.WriteLine("null string entered");
            }
            else
            {
                Console.WriteLine("the email is:" + email);
            }

            #endregion que end



            #region fourth que
            //Console.WriteLine("enter the date is discharge");
            //string dischargeinput = Console.ReadLine();
            //string? dischargedate = null;
            //if (dischargeinput != null)
            //{
            //    Console.WriteLine(" discharged date");
            //    Console.WriteLine($"discharged date is {dischargedate.Value.ToString}");
            //}
            //else
            //{
            //    Console.WriteLine("not discharged now");
            //}
            #endregion 

           

    }
}
}
