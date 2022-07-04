using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext _context;

        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }        

        public async Task<Palestrant[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrant> query = _context.Palestrants
                .AsNoTracking()
                .Include(p => p.RedesSociais)
                .OrderBy(p => p.Id);

                if(includeEventos){
                    query = query
                        .Include(p => p.PalestrantEventos)
                        .ThenInclude(pe => pe.Evento);
                }

            return await query.ToArrayAsync();
        }

        public async Task<Palestrant[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrant> query = _context.Palestrants
                .AsNoTracking()
                .Include(p => p.RedesSociais)
                .OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

                if(includeEventos){
                    query = query
                        .Include(p => p.PalestrantEventos)
                        .ThenInclude(pe => pe.Evento);
                }

            return await query.ToArrayAsync();
        }       

        public async Task<Palestrant> GetPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrant> query = _context.Palestrants
                .AsNoTracking()
                .Include(p => p.RedesSociais)
                .OrderBy(p => p.Id).Where(p => p.Id.Equals(palestranteId));

                if(includeEventos){
                    query = query
                        .Include(p => p.PalestrantEventos)
                        .ThenInclude(pe => pe.Evento);
                }

            return await query.FirstOrDefaultAsync();
        }        
    }
}