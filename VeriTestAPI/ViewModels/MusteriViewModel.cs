namespace VeriTestAPI.ViewModels
{
    public class MusteriViewModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.UtcNow;
    }
}
