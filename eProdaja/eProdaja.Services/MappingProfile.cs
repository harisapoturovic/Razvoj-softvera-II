using AutoMapper;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;

namespace eProdaja.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //dozvole za mapirianje
            CreateMap<Korisnici, Model.Korisnici>();
            CreateMap<KorisniciInsertRequest, Korisnici>();
            CreateMap<KorisniciUpdateRequest, Korisnici>();
            CreateMap<JediniceMjere, Model.JediniceMjere>();
            CreateMap<VrsteProizvodum, Model.VrsteProizvoda>();
        }

    }
}