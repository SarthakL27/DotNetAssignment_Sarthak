using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Assignment2.Model
{
    abstract class VehicleType
    {
        public double BaseAmount { get; set; }
        public double BasePremium { get; set; }

        public VehicleType(double amount, double premium)
        {
            BaseAmount = amount;
            BasePremium = premium;
        }

        public abstract double InsuranceCalc();
    }
}
