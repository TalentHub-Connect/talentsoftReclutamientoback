using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using talentsoftReclutamiento.Data;
using talentsoftReclutamiento.Models;

namespace talentsoftReclutamiento.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CurriculumController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("obtener-curriculums")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen
        public async Task<IActionResult> getAllCurriculums()
        {
            var allCurriculums = await _appDbContext.curriculum.ToListAsync();
            return Ok(allCurriculums);
        }


        [HttpGet("obtener-curriculum/{id}")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> GetCurriculum(int id)
        {
            var curriculum = await _appDbContext.curriculum.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return Ok(curriculum);
        }

        [HttpPost("agregar-curriculum")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> AddCurriculum([FromBody] Curriculum curriculum)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.curriculum.Add(curriculum);
                await _appDbContext.SaveChangesAsync();

                return Ok(curriculum);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("actualizar-curriculum/{id}")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> UpdateCurriculum(int id, [FromBody] Curriculum curriculum)
        {
            var existingCurriculum = await _appDbContext.curriculum.FindAsync(id);
            if (existingCurriculum == null)
            {
                return NotFound();
            }

            existingCurriculum.Address = curriculum.Address;
            existingCurriculum.Personalobjetive = curriculum.Personalobjetive;
            existingCurriculum.Workexperience = curriculum.Workexperience;
            existingCurriculum.Educationalhistory = curriculum.Educationalhistory;
            existingCurriculum.Language = curriculum.Language;
            existingCurriculum.Certification = curriculum.Certification;
            existingCurriculum.Personalreference = curriculum.Personalreference;
            existingCurriculum.University = curriculum.University;
            existingCurriculum.Career = curriculum.Career;

            if (ModelState.IsValid)
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(existingCurriculum);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("eliminar-curriculum/{id}")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> DeleteCurriculum(int id)
        {
            var curriculum = await _appDbContext.curriculum.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            _appDbContext.curriculum.Remove(curriculum);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
