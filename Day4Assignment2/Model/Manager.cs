using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Assignment2.Model
{
    class Manager : Employee
    {
        public decimal Bonus { get; set; }
        public Manager(string name, decimal salary,decimal bonus) : base(name, salary)
        {
            Bonus = bonus;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();

            Console.WriteLine($"Bonus:{Bonus}");
        }
    }
}
