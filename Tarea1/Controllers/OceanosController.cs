using Microsoft.AspNetCore.Mvc;
using Tarea1.Data;
using Tarea1.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OceanosController : ControllerBase
    {
        private static OceanoData data = new OceanoData();
        // GET: api/<OceanosController>
        [HttpGet]
        public List<Oceano> Get()
        {
            List<Oceano> listaOceanos = new List<Oceano>();
            listaOceanos = data.ListarOceanos();
            return listaOceanos;
        }

        // GET api/<OceanosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(data.filtrado(id));
        }

        [HttpGet]
        [Route("api/ListaPezporOceano/{id}")]
        public IActionResult ListarPezporOceano(int id)
        {
            return Ok(data.ListarPezporOceano(id));
        }

        // POST api/<OceanosController>
        [HttpPost]
        public IActionResult Post([FromBody] Oceano oceano)
        {
            if (data.AgregarOceano(oceano))
                return Ok();
            else
                return BadRequest();
        }

        // PUT api/<OceanosController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Oceano oceano)
        {
            if(data.EditarOceano(oceano))
                return Ok();
            else
                return BadRequest();
        }

        // DELETE api/<OceanosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (data.EliminarOceano(id))
                return Ok();
            else
                return BadRequest();

        }
    }
}
