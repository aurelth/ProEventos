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
    public class EventoPersist : IEventoPersist
    {
        private readonly ProEventosContext _context;

        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }                      

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .AsNoTracking()
                .Include(e => e.Lots)
                .Include(e => e.RedeSociais)                
                .OrderBy(e => e.Id);

                if(includePalestrantes){
                    query = query
                        .Include(e => e.PalestrantEventos)
                        .ThenInclude(pal => pal.Palestrant);
                }

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .AsNoTracking()
                .Include(e => e.Lots)
                .Include(e => e.RedeSociais)                
                .OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

                if(includePalestrantes){
                    query = query
                        .Include(e => e.PalestrantEventos)
                        .ThenInclude(pal => pal.Palestrant);
                }
                
            return await query.ToArrayAsync();
        }

         public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .AsNoTracking()
                .Include(e => e.Lots)
                .Include(e => e.RedeSociais)                
                .OrderBy(e => e.Id)
                .Where(e => e.Id.Equals(eventoId));

                if(includePalestrantes){
                    query = query
                        .Include(e => e.PalestrantEventos)
                        .ThenInclude(pal => pal.Palestrant);
                }
                
            return await query.FirstOrDefaultAsync();
        }        
    }
}