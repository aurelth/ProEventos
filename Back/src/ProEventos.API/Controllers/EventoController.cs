using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Application.Contratos;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventosService _eventosService;

        public EventoController(IEventosService eventosService)
        {            
            _eventosService = eventosService;
        }              

        [HttpGet]
        public async Task<IActionResult> Get()
        {   
           try
           {
             var eventos = await _eventosService.GetAllEventosAsync(true);
             if (eventos == null) 
                return NotFound("Nenhum evento encontrado");

             return Ok(eventos);
           }
           catch (Exception exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar recuperar eventos. Erro: {exception.Message}");
           }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {            
            try
            {
             var evento = await _eventosService.GetEventoByIdAsync(id, true);
             if (evento == null) 
                return NotFound($"Nenhum evento com o Id {id} encontrado");

             return Ok(evento);
            }
           catch (Exception exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar encontrar evento. Erro: {exception.Message}");
           }
        }

        [HttpGet("{id}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {            
            try
            {
             var eventos = await _eventosService.GetAllEventosByTemaAsync(tema);
             if (eventos == null) 
                return NotFound($"Nenhum evento com o tema {tema} encontrado");

             return Ok(eventos);
            }
           catch (Exception exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar encontrar eventos. Erro: {exception.Message}");
           }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model){
            try
            {
             var evento = await _eventosService.AddEventos(model);
             if (evento == null)
                return BadRequest($"Erro ao tentar inserir evento");

             return Ok(evento);
            }
           catch (Exception exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar inserir evento. Erro: {exception.Message}");
           }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model){
            try
            {
             var evento = await _eventosService.UpdateEvento(id, model);
             if (evento == null) 
                return BadRequest($"Erro ao tentar atualizar evento");

             return Ok(evento);
            }
           catch (Exception exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar atualizar evento. Erro: {exception.Message}");
           }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            try
            {
                return await _eventosService.DeleteEvento(id) ? Ok("Excluído com sucesso") : BadRequest("Erro ao tentar excluir o evento");                                      
            }
           catch (Exception exception)
           {
            return this.StatusCode(StatusCodes.Status500InternalServerError, 
            $"Erro ao tentar excluir evento. Erro: {exception.Message}");
           }
        }
    }
}
