using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {        
        Task<Palestrant[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrant[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrant> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
    }
}