using Day5Assignment1.Model;
using System.Security.Principal;

namespace Day5Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> accountNumbers = new List<string>
        {
            "123456", "6789", "abc123", "98765"
        };


            foreach (var accno in accountNumbers)
            {
                try
                {
                    Console.WriteLine($"Validating account no:{accno}");
                    foreach (char c in accno)
                    {
                        if (!char.IsDigit(c))
                        {
                            throw new FormatException("The acc no must contain digit only");
                        }
                    }

                    if (accno != "123456" && accno != "6789")
                    {
                        throw new AccountNotFoundException("The account no entered does not exist");
                    }

                    Console.WriteLine("Account no validated successfully");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
                catch (AccountNotFoundException ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("some error occured:" + e.Message);
                }

                Console.WriteLine();
            }
        }
    }
}
