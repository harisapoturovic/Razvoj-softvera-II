using AutoMapper;
using Azure.Core;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eProdaja.Services.ProizvodiStateMachine
{
    public class DraftProductState : BaseState
    {
        ILogger<DraftProductState> _logger;
        public DraftProductState(ILogger<DraftProductState> logger,IServiceProvider serviceProvider, EProdajaContext context, IMapper mapper) 
            : base(serviceProvider, context, mapper)
        {
            _logger = logger;
        }

        public override async Task<Model.Proizvodi> Update(int id, ProizvodiUpdateRequest request)
        {
            var set = _context.Set<Database.Proizvodi>();

            var entity = await set.FindAsync(id);

            _mapper.Map(request, entity);

            if (entity.Cijena < 0)
            {
                throw new Exception("Cijena ne moze biti u minusu"); // => server side error
            }


            if (entity.Cijena < 1)
            {
                throw new UserException("Cijena ispod minimuma");
            }


            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override async Task<Model.Proizvodi> Activate(int id)
        {
            _logger.LogInformation($"Aktivacija proizvoda: {id}");

            _logger.LogWarning($"W: Aktivacija proizvoda: {id}");

            _logger.LogError($"E: Aktivacija proizvoda: {id}");

            
            var set = _context.Set<Database.Proizvodi>();

            var entity = await set.FindAsync(id);

            entity.StateMachine = "active";

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Proizvodi>(entity);
        }

        public override async Task<List<string>> AllowedActions()
        {
            var list = await base.AllowedActions(); //bazna vraća praznu listu

            list.Add("Update");
            list.Add("Activate");

            return list;
        }
    }
}
