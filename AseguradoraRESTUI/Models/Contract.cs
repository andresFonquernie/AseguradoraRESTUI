using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraRESTUI.Models
{
    class Contract
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public Policy policy { get; set; }
    }
}
