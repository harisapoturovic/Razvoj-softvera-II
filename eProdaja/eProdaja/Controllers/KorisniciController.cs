using eProdaja.Model.Requests;
using eProdaja.Services;
using eProdaja.Services.Database;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KorisniciController : Controller
    {
        private readonly IKorisniciService _korisniciService;

        public KorisniciController(IKorisniciService korisniciService)
        {
            _korisniciService = korisniciService;
        }

        [HttpGet]
        public async Task<IEnumerable<Model.Korisnici>> Get()
        {
            return await _korisniciService.Get();
        }

        [HttpPost]
        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            return _korisniciService.Insert(request);
        }

        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            return _korisniciService.Update(id, request);
        }
    }
}
