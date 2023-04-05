using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class BaseService<T, Tdb, Tsearch> :IService<T, Tsearch> where T : class where Tdb : class where Tsearch : BaseSearchObject
    {
        protected EProdajaContext _context;
        protected IMapper _mapper { get; set; }

        public BaseService(EProdajaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //zajedničko za sve
        public virtual async Task<PagedResult<T>> Get(Tsearch? search=null)
        {
            var query = _context.Set<Tdb>().AsQueryable();

            PagedResult<T> result = new PagedResult<T>();

            query = AddFilter(query, search);

            query = AddInclude(query, search);

            result.Count = await query.CountAsync(); //broj redova u bazi nakon filtriranja

            if (search?.Page.HasValue==true && search?.PageSize.HasValue==true)
            {
                query=query.Take(search.PageSize.Value).Skip(search.Page.Value * search.PageSize.Value);
            }

            var list = await query.ToListAsync();

            var tmp = _mapper.Map<List<T>>(list);
            result.Result = tmp;
            return result;
        }

        public virtual IQueryable<Tdb> AddInclude(IQueryable<Tdb> query, Tsearch? search = null)
        {
            return query;
        }

        public virtual IQueryable<Tdb> AddFilter(IQueryable<Tdb> query, Tsearch? search= null)
        {
            return query;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _context.Set<Tdb>().FindAsync(id);

            return _mapper.Map<T>(entity);
        }
    }
}
