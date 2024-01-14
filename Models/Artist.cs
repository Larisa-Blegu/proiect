namespace proiect.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistDescription { get; set; }
        public ICollection<Curs> Cursuri { get; set; }
    }
}
