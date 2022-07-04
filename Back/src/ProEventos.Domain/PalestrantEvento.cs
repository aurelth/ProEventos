using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class PalestrantEvento
    {
        public int PalestrantId { get; set; }
        public Palestrant Palestrant { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}