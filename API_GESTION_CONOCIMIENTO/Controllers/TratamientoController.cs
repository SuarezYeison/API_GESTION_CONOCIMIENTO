using API_GESTION_CONOCIMIENTO.Data;
using API_GESTION_CONOCIMIENTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_GESTION_CONOCIMIENTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly GestionConocimientoDbContext dbContext;

        public TratamientoController(GestionConocimientoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{IdTratamiento:int}")]
        public IActionResult GetTratamientoById(int IdTratamiento)
        {
            var tratamiento = dbContext.Tratamientos.Find(IdTratamiento);

            if (tratamiento == null)
            {
                return NotFound();
            }

            return Ok(tratamiento);
        }

        [HttpGet]
        public IActionResult GetTratamiento()
        {
            var listTratamientos = dbContext.Tratamientos.ToList();

            return Ok(listTratamientos);
        }

        [HttpPost]
        public IActionResult CreateTratamiento(Tratamiento tratamiento)
        {
            var tratamientoModel = new Tratamiento()
            {
                NombreT = tratamiento.NombreT
            };

            dbContext.Tratamientos.Add(tratamientoModel);
            dbContext.SaveChanges();

            return Ok(tratamientoModel);
        }

        [HttpPut]
        [Route("{IdTratamiento:int}")]
        public IActionResult UpdateTratamiento(int IdTratamiento, Tratamiento tratamiento)
        {
            var tratamientoModel = dbContext.Tratamientos.Find(IdTratamiento);

            if (tratamientoModel == null)
            {
                return NotFound();
            }

            tratamientoModel.NombreT = tratamiento.NombreT;
            dbContext.SaveChanges();

            return Ok(tratamientoModel);
        }

        [HttpDelete]
        [Route("{IdTratamiento:int}")]
        public IActionResult DeleteEnfermedad(int IdTratamiento)
        {
            var tratamientoModel = dbContext.Tratamientos.Find(IdTratamiento);

            if (tratamientoModel == null)
            {
                return NotFound();
            }

            dbContext.Tratamientos.Remove(tratamientoModel);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
