using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoPolicy.Models
{
    class Policy
    {
        public int PolicyID { get; set; }

        public string PolicyHolderName { get; set; }

        public int CustomerID { get; set; }

        public int PolicyType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
