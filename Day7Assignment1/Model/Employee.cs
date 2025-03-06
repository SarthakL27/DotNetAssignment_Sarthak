using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Assignment1.Model
{
    class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public DateTime JoinDate { get; }

        public Employee(int id, string name, DateTime joinDate)
        {
            Id = id;
            Name = name;
            JoinDate = joinDate;
        }
    }
}
