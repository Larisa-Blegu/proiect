using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class TipBilet
    {
        public int ID { get; set; }
        public string BiletType { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal BiletPrice { get; set; }
    }
}
