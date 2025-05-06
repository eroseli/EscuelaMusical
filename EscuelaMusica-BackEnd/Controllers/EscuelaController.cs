using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EscuelaMusica_BackEnd.Models;
using EscuelaMusica_BackEnd.Services;
using EscuelaMusica_BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EscuelaMusica_BackEnd.Controllers
{

    [Route("api/[controller]")]
    public class EscuelaController : Controller
    {
        private readonly IEscuelaService escuelaService;

        public EscuelaController(IEscuelaService escuelaService) {
            this.escuelaService = escuelaService;
        }

            // GET: api/values
            [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await escuelaService.obtenerEscuelas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await escuelaService.ObtenerEscuelaId(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Escuela escuela )
        {
            var respuesta = await escuelaService.insertarEscuela(escuela);
            return Ok(respuesta);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody]Escuela escuela)
        {
            return Ok(await escuelaService.actualizarEscuela(escuela));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await escuelaService.eliminarEscuela(id));
        }
    }
}

