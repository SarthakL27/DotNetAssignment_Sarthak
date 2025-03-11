using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoPolicy.Interfaces
{
    interface IloginandRegister
    {
        public bool Loggin(int id, string password);
        public void Register(string name, string password);
    }
}
