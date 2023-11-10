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
            var musteriler = _context.Musteriler.ToList();
            if (musteriler != null)
            {
                return JsonSerializer.Serialize(musteriler);
            }
            else
            {
                return "Müşteriler bulunamadı";
            }
            
        }

        public string Get(int id)
        {
            var musteri = _context.Musteriler.FirstOrDefault(x => x.Id == id);
            if(musteri != null)
            {
                return JsonSerializer.Serialize(musteri);
            }
            else
            {
                return "Müşteri bulunamadı";
            }
        }

        public string Post(MusteriViewModel yeniMusteri)
        {
            var AddMusteri = new Musteri
            {
                Ad = yeniMusteri.Ad,
                Soyad = yeniMusteri.Soyad,
                Telefon = yeniMusteri.Telefon,
                OlusturulmaTarihi = DateTime.UtcNow
            };
            _context.Musteriler.Add(AddMusteri);
            _context.SaveChanges();
            return "";
        }

        public string Put(int id, MusteriViewModel guncelMusteri)
        {
            var musteri = _context.Musteriler.FirstOrDefault(x => x.Id == id);
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
            var musteri = _context.Musteriler.FirstOrDefault(x => x.Id == id);
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
