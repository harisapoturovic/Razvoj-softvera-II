using eProdaja.Model;
using eProdaja.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BaseController<T, Tsearch> : ControllerBase where T : class where Tsearch : class
    {
        protected readonly IService<T, Tsearch> _service;
        protected readonly ILogger<BaseController<T, Tsearch>> _logger;

        public BaseController(IService<T, Tsearch> service, ILogger<BaseController<T, Tsearch>> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<PagedResult<T>> Get([FromQuery] Tsearch? search=null)
        {
            return await _service.Get(search);
        }

        [HttpGet("{id}")]
        public async Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
    }
}
