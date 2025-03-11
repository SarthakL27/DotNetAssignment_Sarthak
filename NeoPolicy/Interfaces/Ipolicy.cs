using NeoPolicy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoPolicy.Interfaces
{
    interface Ipolicy
    {
        public bool AddPolicy(int cutomerId, string name,int PolicyType,int PolicyPeriod);

        public List<Policy>  ViewAllPolicy(int customerId);

        public List<Policy> SearchPolicyById(int customerId, int policyId);

        public bool UpdatePolicyById(int customerId, int policyId);

        public bool DeletePolicy(int customerId, int policyId);

        public List<Policy> ShowActivePolicy(int customerId);




    }
}
