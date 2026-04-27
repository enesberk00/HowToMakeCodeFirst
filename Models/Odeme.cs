namespace HowToMakeCodeFirst.Models
{
    public class Odeme
    {
        public int OdemeId { get; set; }
        public decimal OdemeTutar { get; set; }
        public DateTime OdemeTarihi { get; set; }   
        public string OdemeYontemi { get; set; }
        public int OdemeRezervasyon_Id { get; set; }

        public Rezervasyon Rezervasyon { get; set; }
    }
}
