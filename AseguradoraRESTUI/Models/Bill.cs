using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraRESTUI.Models
{
    class Bill
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public int MoneyToPay { get; set; }
    }
}
