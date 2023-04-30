using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECashier_Console_App.Models
{
    internal class ECashier
    { 
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public char Response { get; set; }
        public bool Activation { get; set; } = true;
        public List<Account> Accounts { get; set; }

        public ECashier() { 
        Accounts=new List<Account>();
        }
    }
}
