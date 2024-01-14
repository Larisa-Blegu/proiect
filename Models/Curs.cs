using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace proiect.Models
{
    public class Curs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Locatie { get; set; }
        public DateTime Date { get; set; }
        public int? ArtistID { get; set; }
        public Artist? Artist { get; set; }

        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

    }
}

