namespace HowToMakeCodeFirst.Models
{
    public class Rezervasyon
    {
        public int RezervasyonId { get; set; }
        public DateTime RezervasyonGiris { get; set; }
        public DateTime RezervasyonCikis { get; set; }
        public decimal RezervasyonTutar { get; set; }
        public string RezervasyonDurumu { get; set; }

        public int RezervasyonMusteri_Id { get; set; }
        public int RezervastonOda_Id { get; set; }

        public Musteri Musteri { get; set; }
        public Oda Oda  { get; set; }

        public ICollection<Odeme> Odemeler { get; set; }
    }
}
