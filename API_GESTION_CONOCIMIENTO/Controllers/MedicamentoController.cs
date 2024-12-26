using API_GESTION_CONOCIMIENTO.Data;
using API_GESTION_CONOCIMIENTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_GESTION_CONOCIMIENTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly GestionConocimientoDbContext dbContext;

        public MedicamentoController(GestionConocimientoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{IdMedicamento:int}")]
        public IActionResult GetMedicamentoById(int IdMedicamento)
        {
            var medicamento = dbContext.Medicamentos.Find(IdMedicamento);

            if (medicamento == null)
            {
                return NotFound();
            }

            return Ok(medicamento);
        }


        [HttpGet]
        public IActionResult GetMedicamento()
        {
            var listNedicamentos = dbContext.Medicamentos.ToList();

            return Ok(listNedicamentos);
        }

        [HttpPost]
        public IActionResult CreateMedicamento(Medicamento medicamento)
        {
            var medicamentoModel = new Medicamento()
            {
                NombreM = medicamento.NombreM
            };

            dbContext.Medicamentos.Add(medicamentoModel);
            dbContext.SaveChanges();

            return Ok(medicamentoModel);
        }

        [HttpPut]
        [Route("{IdMedicamento:int}")]
        public IActionResult UpdateMedicamento(int IdMedicamento, Medicamento medicamento)
        {
            var medicamentoModel = dbContext.Medicamentos.Find(IdMedicamento);

            if (medicamentoModel == null)
            {
                return NotFound();
            }

            medicamentoModel.NombreM = medicamento.NombreM;
            dbContext.SaveChanges();

            return Ok(medicamentoModel);
        }

        [HttpDelete]
        [Route("{IdMedicamento:int}")]
        public IActionResult DeleteMedicamento(int IdMedicamento)
        {
            var medicamentoModel = dbContext.Medicamentos.Find(IdMedicamento);

            if (medicamentoModel == null)
            {
                return NotFound();
            }

            dbContext.Medicamentos.Remove(medicamentoModel);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
