using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Assignment2.Model
{
    internal class FourWheeler : VehicleType
    {

        public FourWheeler(double amount, double premium) : base(amount, premium)
        {
        }

        public override double InsuranceCalc()
        {
            return BaseAmount * BaseAmount;
        }
    }
}
