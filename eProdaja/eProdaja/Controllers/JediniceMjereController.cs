using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [ApiController]
    public class JediniceMjereController : BaseController<Model.JediniceMjere, JediniceMjereSearchObject>
    {
        public JediniceMjereController(IJediniceMjereService service, ILogger<BaseController<JediniceMjere, JediniceMjereSearchObject>> logger) 
            : base(service, logger)
        {
        }
    }
}
