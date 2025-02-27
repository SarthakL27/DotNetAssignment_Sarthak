using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day4Assignment2.Model
{
    class Employee
    {
       public string Name { get; set; }
       
        public decimal Salary { get; set; }

        public Employee(string name,decimal salary)
        {
            Salary = salary;
            Name = name;
        }

        public  virtual void DisplayDetails()
        {
            Console.WriteLine($"Name:{ Name}");
            Console.WriteLine($"Salary:{Salary}");


        }
    }
}
