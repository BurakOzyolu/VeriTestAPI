namespace VeriTestAPI.ViewModels
{
    public class HarcamaViewModel
    {
        public int HarcamaId { get; set; }
        public int MusteriId { get; set; }
        public float Tutar { get; set; }
        public bool OdenmeDurumu { get; set; } = false;
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.UtcNow;
        public DateTime OdenmeTarihi { get; set; }
    }
}
