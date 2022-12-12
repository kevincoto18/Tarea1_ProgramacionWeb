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
        [HttpGet]
        [Route("api/OceanosporPez/{identificador}")]
        public IActionResult ListarOceanosdePez(int identificador)
        {
            return Ok(data.OceanosxPez(identificador));
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
        [HttpPost]
        [Route("api/AgregarOceanoaPez/{id_pez}/{id_oceano}")]
        public IActionResult AgregarOceanoalPez(int id_pez, int id_oceano)
        {
            if (data.AgregarOceanoPez(id_pez, id_oceano))
                return Ok();
            else
                return BadRequest();
        }

        // PUT api/<Peces>/5
        [HttpPut]
        public IActionResult Put([FromBody] Pez pez)
        {
            if (data.PezEditado(pez))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("api/EditarOceanosdePez/{id}")]
        public IActionResult EditarOceanosdePez(int id, [FromBody] Oceano oceano)
        {
            if (data.EditarOceanoporPez(id, oceano))
                return Ok();
            else
                return BadRequest();
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
