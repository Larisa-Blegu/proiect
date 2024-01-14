using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Inscriere
    {
        public int ID { get; set; }

        [Required (ErrorMessage= "Cursul este obligatoriu de selectat.")]
        [Display (Name = "Curs")]
        public int? CursID { get; set; }

        [Required(ErrorMessage = "Tip Bilet este obligatoriu de selectat.")]
        [Display(Name = "Tip Bilet")]
        public int? TipBiletID { get; set; }

        [Required(ErrorMessage = "Clientul este obligatoriu de selectat.")]
        [Display(Name = "Client")]
        public int? ClientID { get; set; }

        public Client? Client { get; set; }
        public Curs? Curs { get; set; }
        public TipBilet?    TipBilet { get; set;}   

       
    }
}
