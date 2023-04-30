using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECashier_Console_App.Models
{
    internal class Account:ECashier
    {
        public int AccountID { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public string Assignment { get; set; }
        public string ActivationStatus { get; set; }
    }
}
