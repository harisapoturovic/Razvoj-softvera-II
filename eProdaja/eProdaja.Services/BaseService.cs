using AutoMapper;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseService<T, Tdb>:IService<T> where T : class where Tdb : class
    {
        EProdajaContext _context;
        public IMapper _mapper { get; set; }

        public BaseService(EProdajaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<T>> Get()
        {
            var query = _context.Set<Tdb>().AsQueryable();

            var list = await query.ToListAsync();

            return _mapper.Map<List<T>>(list);
        }
    }
}
