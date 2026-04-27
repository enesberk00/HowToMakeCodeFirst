namespace HowToMakeCodeFirst.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public string MusteriTelNo { get; set; }
        public string MusteriTcNo { get; set; }
        public DateTime MusteriKayıtTarihi { get; set; }

        public ICollection<Rezervasyon>? Rezervasyonlar { get; set; }

    }
}
