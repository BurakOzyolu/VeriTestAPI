using Microsoft.AspNetCore.Mvc;
using VeriTestAPI.Models;
using VeriTestAPI.Repositories;
using VeriTestAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VeriTestAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        MyContext _context;
        MusteriRepositories _musteriRepo;
        public MusteriController(MyContext context)
        {
            _context = context;
            _musteriRepo = new MusteriRepositories(_context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var musteriler = _context.Musteriler.ToList();
            return Ok(musteriler);
        }

        // GET api/<MusteriController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var musteri = _musteriRepo.Get(id);
            return Ok(musteri);
        }

        // POST api/<MusteriController>
        [HttpPost]
        public IActionResult Post(MusteriViewModel yeniMusteri)
        {
            var AddMusteri = _musteriRepo.Post(yeniMusteri);
            return Ok(AddMusteri);
        }

        // PUT api/<MusteriController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, MusteriViewModel guncelMusteri)
        {
            var musteri = _musteriRepo.Put(id, guncelMusteri);
            return Ok(musteri);
        }

        // DELETE api/<MusteriController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var musteri =  _musteriRepo.Delete(id);
            return Ok(musteri);
        }
    }
}
