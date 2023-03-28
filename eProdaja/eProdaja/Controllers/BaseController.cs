using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IService<T> _service;
        private readonly ILogger<BaseController<T>> _logger;

        public BaseController(IService<T> service, ILogger<BaseController<T>> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<T>> Get()
        {
            return await _service.Get();
        }
    }
}
