using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    public class VrsteProizvodaController : BaseController<VrsteProizvoda>
    {
        public VrsteProizvodaController(IService<VrsteProizvoda> service, ILogger<BaseController<VrsteProizvoda>> logger) 
            : base(service, logger)
        {
        }
    }
}
