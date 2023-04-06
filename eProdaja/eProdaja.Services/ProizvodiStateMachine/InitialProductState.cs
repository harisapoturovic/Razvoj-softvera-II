using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class InitialProductState : BaseState
    {
        public InitialProductState(IServiceProvider serviceProvider, Database.EProdajaContext context, IMapper mapper) 
            : base(serviceProvider, context, mapper)
        {
        }

        //dozvoljavamo insert
        public override async Task<Proizvodi> Insert(ProizvodiInsertRequest request)
        {
            var set = _context.Set<Database.Proizvodi>();

            var entity = _mapper.Map<Database.Proizvodi>(request);

            entity.StateMachine = "draft"; //proizvod se inserta u stanju draft

            set.Add(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Proizvodi>(entity);
        }
    }
}
