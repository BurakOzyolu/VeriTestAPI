namespace VeriTestAPI.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public ICollection<Harcama>? Harcamalar { get; set; }
    }
}
