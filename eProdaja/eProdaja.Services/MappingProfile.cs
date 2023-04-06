﻿using AutoMapper;
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

            CreateMap<KorisniciUloge, Model.KorisniciUloge>();
            CreateMap<Uloge, Model.Uloge>();

            CreateMap<Proizvodi, Model.Proizvodi>();
            CreateMap<ProizvodiInsertRequest, Proizvodi>();
            CreateMap<ProizvodiUpdateRequest, Proizvodi>();
        }

    }
}