using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Assignment1.Model
{
    class AccountNotFoundException:Exception
    {
        public AccountNotFoundException(string message) : base(message)
        {

        }
    }
}
