namespace HowToMakeCodeFirst.Models
{
    public class Oda
    {
        public int OdaId { get; set; }
        public string OdaNo { get; set; }
        public int OdaKapasite { get; set; }
        public int OdaFiyat { get; set; }
        public bool OdaDurum { get; set; }
        public int OdaOtel_Id { get; set; }

        public Otel Otel { get; set; }

        public ICollection<Rezervasyon > Rezervasyonlar { get; set; }


    }
}
