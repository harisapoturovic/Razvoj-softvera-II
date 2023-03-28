using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    public class JediniceMjereController : BaseController<Model.JediniceMjere>
    {
        public JediniceMjereController(IJediniceMjereService service, ILogger<BaseController<JediniceMjere>> logger) : base(service, logger)
        {
        }
    }
}
