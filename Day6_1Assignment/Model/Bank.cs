using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6_1Assignment.Model
{
   internal class Bank
    {
        public string UserName { get; set; }

        Queue<string> toknque = new Queue<string>();
        public Bank()
        {
            toknque.Enqueue("Sarthak");
            toknque.Enqueue("shreekanth");
        }

        public void AddToken(string user)
        {
            UserName = user;
            toknque.Enqueue(UserName);
            Console.WriteLine($"Welcome {UserName}, you are in queue . Your wait number is {toknque.Count}.");
        }
        public string CheckNext()
        {
            return $"Next in line is {toknque.Peek()}";
        }

    }
}
