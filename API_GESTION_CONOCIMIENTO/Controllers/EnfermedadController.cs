using API_GESTION_CONOCIMIENTO.Data;
using API_GESTION_CONOCIMIENTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_GESTION_CONOCIMIENTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadController : ControllerBase
    {
        private readonly GestionConocimientoDbContext dbContext;

        public EnfermedadController(GestionConocimientoDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{IdEnfermedad:int}")]
        public IActionResult GetEnfermedadById(int IdEnfermedad)
        {
            var enfermedad = dbContext.Enfermedades.Find(IdEnfermedad);

            if (enfermedad == null) 
            {
                return NotFound();            
            }

            return Ok(enfermedad);
        }

        [HttpGet]
        public IActionResult GetEnfermedad()
        {
            var listEnfermedades = dbContext.Enfermedades.ToList();

            return Ok(listEnfermedades);
        }

        [HttpPost]
        public IActionResult CreateEnfermedad(Enfermedad enfermedad)
        {
            var enfermedadModel = new Enfermedad()
            {
                NombreE = enfermedad.NombreE
            };

            dbContext.Enfermedades.Add(enfermedadModel);
            dbContext.SaveChanges();

            return Ok(enfermedadModel);
        }

        [HttpPut]
        [Route("{IdEnfermedad:int}")]
        public IActionResult UpdateEnfermedad(int IdEnfermedad, Enfermedad enfermedad)
        {
            var enfermedadModel = dbContext.Enfermedades.Find(IdEnfermedad);

            if (enfermedadModel == null)
            {
                return NotFound();
            }

            enfermedadModel.NombreE = enfermedad.NombreE;
            dbContext.SaveChanges();

            return Ok(enfermedadModel);
        }

        [HttpDelete]
        [Route("{IdEnfermedad:int}")]
        public IActionResult DeleteEnfermedad(int IdEnfermedad)
        {
            var enfermedadModel = dbContext.Enfermedades.Find(IdEnfermedad);

            if (enfermedadModel == null)
            {
                return NotFound();
            }

            dbContext.Enfermedades.Remove(enfermedadModel);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
