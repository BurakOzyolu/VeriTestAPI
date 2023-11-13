using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeriTestAPI.Models;
using VeriTestAPI.ViewModels;

namespace VeriTestAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IslemController : ControllerBase
    {
        MyContext _context;
        public IslemController(MyContext context)
        {
            _context = context;
        }

        //Harcama İşlemi
        [HttpPost]
        public IActionResult Harcama(HarcamaViewModel yeniHarcama)
        {
            Harcama harcama = new Harcama
            {
                Tutar = yeniHarcama.Tutar,
                MusteriId = yeniHarcama.MusteriId,
                OdenmeDurumu = false
            };
            _context.Harcamalar.Add(harcama);
            _context.SaveChanges();
            return Ok(harcama);
        }
        //Ödeme İşlemi
        [HttpPost]
        public IActionResult Odeme(int harcamaId)
        {
            var harcama = _context.Harcamalar.FirstOrDefault(x => x.HarcamaId == harcamaId);
            if (harcama != null)
            {
                harcama.OdenmeDurumu = true;
                _context.SaveChanges();
            }
            return Ok(harcama);
        }
        //Müşteri Ödeme Listesi
        [HttpGet]
        public IActionResult OdemeListesi(int musteriId)
        {
            var odemeListesi = _context.Harcamalar.Where(x => x.MusteriId == musteriId && x.OdenmeDurumu == true);
            return Ok(odemeListesi);
        }
        //Müşteri Borç Listesi
        [HttpGet]
        public IActionResult BorcListesi(int musteriId)
        {
            var odemeListesi = _context.Harcamalar.Where(x => x.MusteriId == musteriId && x.OdenmeDurumu == false);
            return Ok(odemeListesi);
        }
        //Müşteri Tüm Harcama Listesi
        [HttpGet]
        public IActionResult HarcamaListesi(int musteriId)
        {
            var odemeListesi = _context.Harcamalar.Where(x => x.MusteriId == musteriId);
            return Ok(odemeListesi);
        }
        //Her Müşterinin Toplam Borcu
        [HttpGet]
        public IActionResult ToplamBorc()
        {
            var odemeListesi = _context.Harcamalar.Where(x=>x.OdenmeDurumu==false).GroupBy(x=> x.MusteriId).Select(x=> new { HesapNo =x.Select(x=>x.MusteriId), Borc=x.Select(x=>x.Tutar).Sum() }).ToList();
            return Ok(odemeListesi);
        }
        //Her Müştetri Toplam Harcama

    }
}
