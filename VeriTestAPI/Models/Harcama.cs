namespace VeriTestAPI.Models
{
    public class Harcama
    {
        public int HarcamaId { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public float Tutar { get; set; }
        public bool OdenmeDurumu { get; set; }
    }
}
