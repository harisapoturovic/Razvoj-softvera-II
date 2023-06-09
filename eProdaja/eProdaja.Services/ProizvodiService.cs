﻿using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Model.SearchObjects;
using eProdaja.Services.Database;
using eProdaja.Services.ProizvodiStateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : BaseCRUDService<Model.Proizvodi, Database.Proizvodi, ProizvodiSearchObject, ProizvodiInsertRequest, ProizvodiUpdateRequest>, IProizvodiService
    {
        public BaseState _baseState { get; set; }

        public ProizvodiService(EProdajaContext context, IMapper mapper, BaseState baseState)
            : base(context, mapper)
        {
            _baseState = baseState;
        }

        public override IQueryable<Database.Proizvodi> AddFilter(IQueryable<Database.Proizvodi> query, ProizvodiSearchObject? search = null)
        {
            var filteredQuery = base.AddFilter(query, search);
            if(!string.IsNullOrWhiteSpace(search?.FTS))
            {
                filteredQuery = filteredQuery.Where(x => x.Naziv.Contains(search.FTS) || x.Sifra.Contains(search.FTS));
            }

            if (!string.IsNullOrWhiteSpace(search?.Sifra))
            {
                filteredQuery = filteredQuery.Where(x => x.Sifra == search.Sifra);
            }
            return filteredQuery;
        }

        public override Task<Model.Proizvodi> Insert(ProizvodiInsertRequest insert)
        {
            var state = _baseState.CreateState("initial");

            return state.Insert(insert);
        }

        public override async Task<Model.Proizvodi> Update(int id, ProizvodiUpdateRequest update)
        {
            var entity = await _context.Proizvodis.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Update(id, update);
        }

        public async Task<Model.Proizvodi> Activate(int id)
        {
            var entity = await _context.Proizvodis.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Activate(id);
        }

        public async Task<Model.Proizvodi> Hide(int id)
        {
            var entity = await _context.Proizvodis.FindAsync(id);

            var state = _baseState.CreateState(entity.StateMachine);

            return await state.Hide(id);
        }

        public async Task<List<string>> AllowedActions(int id)
        {
            var entity = await _context.Proizvodis.FindAsync(id);

            var state = _baseState.CreateState(entity?.StateMachine ?? "initial"); //entity može biti null ako se radi insert (id==0)

            return await state.AllowedActions();
        }
    }
}
