namespace Day3Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter your password");
            String psswrd = Console.ReadLine();

            if (psswrd.Length < 6)
            {
                Console.WriteLine("too short password atleast enter 6 letters");
            }
            if (!psswrd.Any(char.IsUpper))
            {
                Console.WriteLine("should have atleast one upper case");
            }
            if (!psswrd.Any(char.IsDigit))
            {
                Console.WriteLine("should have atleast 1 digit");
            }

        }
    }
}
