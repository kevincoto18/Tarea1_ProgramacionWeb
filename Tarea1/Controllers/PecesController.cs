using Microsoft.AspNetCore.Mvc;
using Tarea1.Data;
using Tarea1.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecesController : ControllerBase
    {
        private static PezData data = new PezData();
        // GET: api/<Peces>
        [HttpGet]
        public List<Pez> Get()
        {
            return data.ListarPeces();
        }

        // GET api/<Peces>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(data.filtrado(id));
        }

        // POST api/<Peces>
        [HttpPost]
        public IActionResult Post([FromBody] Pez pez)
        {
            if (data.AgregarPez(pez))
                return Ok();
            else
                return BadRequest();
        }
        [HttpPost("{id_pez},{id_oceano}")]
        public IActionResult AgregarOceano(int id_pez,int id_oceano)
        {
            if (data.AgregarOceanoPez(id_pez,id_oceano))
                return Ok();
            else
                return BadRequest();
        }

        // PUT api/<Peces>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pez pez)
        {
        }

        // DELETE api/<Peces>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (data.EliminarPez(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
