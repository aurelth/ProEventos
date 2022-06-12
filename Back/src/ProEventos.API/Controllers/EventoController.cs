using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {        
        public EventoController()
        {
        }

        public IEnumerable<Evento> _eventos = new Evento[]
        {
            new Evento()
                {
                    EventoId = 1,
                    Tema = "Treinamento .NET Core 5 e Angular 11",
                    Local = "Blumenau",
                    Lote = "Primeira Classe",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImageURL = "https://www.ieee.org/content/dam/ieee-org/ieee/web/org/landing-page-carousel/ieee-meetings-conferences-events-mce.jpg"
                },
                new Evento()
                {
                    EventoId = 2,
                    Tema = "RestFul APIs com .NET Core 5 e Angular 11",
                    Local = "São Paulo",
                    Lote = "Business Classe",
                    QtdPessoas = 473,
                    DataEvento = DateTime.Now.AddDays(4).ToString("dd/MM/yyyy"),
                    ImageURL = "image.jpg"
                }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {    
            return _eventos;
            
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {    
            return _eventos.Where(evento => evento.EventoId.Equals(id));
            
        }
    }
}
