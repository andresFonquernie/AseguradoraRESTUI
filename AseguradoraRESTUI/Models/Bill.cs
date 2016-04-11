
namespace AseguradoraRESTUI.Models
{
    class Bill
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public int moneyToPay { get; set; }
    }
}
