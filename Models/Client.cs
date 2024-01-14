using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }

    }
}
