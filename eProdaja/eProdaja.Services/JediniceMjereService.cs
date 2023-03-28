using AutoMapper;
using eProdaja.Model;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JediniceMjere = eProdaja.Services.Database.JediniceMjere;

namespace eProdaja.Services
{
    public class JediniceMjereService : BaseService<Model.JediniceMjere, JediniceMjere>, IJediniceMjereService
    {
        public JediniceMjereService(EProdajaContext context, IMapper mapper)
            :base(context, mapper)
        {
        }
    }
}
