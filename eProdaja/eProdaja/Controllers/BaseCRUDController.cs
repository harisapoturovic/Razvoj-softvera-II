using eProdaja.Model.SearchObjects;
using eProdaja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eProdaja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch> where T : class where TInsert : class where TUpdate : class where TSearch : BaseSearchObject
    {
        protected new readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;
        protected readonly ILogger<BaseController<T, TSearch>> _logger;

        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service, ILogger<BaseController<T, TSearch>> logger) 
            : base(service, logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public virtual async Task<T> Insert([FromBody] TInsert insert)
        {
            return await _service.Insert(insert);
        }

        [HttpPut("{id}")]
        public virtual async Task<T> Update(int id, [FromBody] TUpdate update)
        {
            return await _service.Update(id, update);
        }
    }
}
