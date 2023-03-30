using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    public class VrsteProizvodaController : BaseController<VrsteProizvoda, BaseSearchObject>
    {
        public VrsteProizvodaController(IService<VrsteProizvoda, BaseSearchObject> service, ILogger<BaseController<VrsteProizvoda, BaseSearchObject>> logger) 
            : base(service, logger)
        {
        }
    }
}
