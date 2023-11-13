using System.Text.Json;
using VeriTestAPI.Models;
using VeriTestAPI.ViewModels;

namespace VeriTestAPI.Repositories
{
    public class MusteriRepositories
    {
        MyContext _context;
        public MusteriRepositories(MyContext context)
        {
            _context = context;
        }

        public string GetAll()
        {
            try
            {
                var musteriler = _context.Musteriler.ToList();
                return JsonSerializer.Serialize(musteriler);
            }
            catch (Exception)
            {
                return "Müşteriler bulunamadı";
            }
            
            
        }

        public string Get(int id)
        {
            try
            {
                var musteri = _context.Musteriler.FirstOrDefault(x => x.MusteriId == id);
                return JsonSerializer.Serialize(musteri);
            }
            catch
            { 
                return "Müşteri bulunamadı";
            }
        }

        public string Post(MusteriViewModel yeniMusteri)
        {
            Musteri musteri = new Musteri
            {
                Ad = yeniMusteri.Ad,
                Soyad = yeniMusteri.Soyad,
                Telefon = yeniMusteri.Telefon,
                OlusturulmaTarihi = DateTime.UtcNow
            };
            _context.Musteriler.Add(musteri);
            _context.SaveChanges();
            return musteri.Ad + " " + musteri.Soyad + " isimli müşteri eklenmiştir";
        }

        public string Put(int id, MusteriViewModel guncelMusteri)
        {
            var musteri = _context.Musteriler.FirstOrDefault(x => x.MusteriId == id);
            if(musteri != null)
            {
                musteri.Ad = guncelMusteri.Ad;
                musteri.Soyad = guncelMusteri.Soyad;
                musteri.Telefon = guncelMusteri.Telefon;
                _context.SaveChanges();
                return musteri.Ad + " " + musteri.Soyad +" isimli müşteri güncellenmiştir";
            }
            return "Güncellenecek müşteri bulunamadı";
        }

        public string Delete(int id)
        {
            var musteri = _context.Musteriler.FirstOrDefault(x => x.MusteriId == id);
            if (musteri != null)
            {
                var islem = _context.Musteriler.Remove(musteri);
                _context.SaveChanges();
                return "Silme başaralı";
            }
            else
            {
                return "Silme başarısız";
            }
        }
    }
}
