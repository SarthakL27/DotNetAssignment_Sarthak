namespace Day4Assignments
{
    internal class Program
    {
        static int loginCount = 0;
        static void Main(string[] args)
        {
            #region Question1
            while (true)
            {
                Console.WriteLine("Enter username or type 'exit' to quit:");
                string username = Console.ReadLine();

                if (username.ToLower() == "exit")
                {
                    break;
                }
                loginCount++;

                Console.WriteLine($"Hello, {username}. Total logins: {loginCount}");
            }

            Console.WriteLine("Program terminated.");
            #endregion
        }
    }
}
