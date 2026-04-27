namespace HowToMakeCodeFirst.Models
{
    public class Otel
    {

        public int OtelId { get; set; }
        public string OtelAd {  get; set; }
        public string OtelSehir { get; set; }
        public string OtelAdres { get; set; }
        public int OtelYıldızSayısı { get; set; }
        public string OtelTelefon { get; set; }

        public ICollection<Oda> Odalar {  get; set; }   
    }
}
