using System;
using System.Collections.Generic;
using AseguradoraRESTUI.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AseguradoraRESTUI.Models
{
    class Client
    {
        public int ID { get; set; }
        public string DNI { get; set; }
        public string Name { get; set; }
        public List<Bill> Bills { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
