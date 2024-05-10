using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using talentsoftReclutamiento.Data;
using talentsoftReclutamiento.Models;

namespace talentsoftReclutamiento.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public OfferController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        
        [HttpGet("obtener-convocatorias")]
        public async Task<IActionResult> getAllOffers()
        {
            var allOffers = await _appDbContext.offer.ToListAsync();
            return Ok(allOffers);
        }
        
        [HttpGet("obtener-convocatoria/{id}")]
        public async Task<IActionResult> GetOffer(int id)
        {
            var offer = await _appDbContext.offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }
        
        
        [HttpPost("agregar-convocatoria")]
        public async Task<IActionResult> AddOffer([FromBody] Offer offer)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.offer.Add(offer);
                await _appDbContext.SaveChangesAsync();

                return Ok(offer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("actualizar-convocatoria/{id}")]
        public async Task<IActionResult> UpdateOffer(int id, [FromBody] Offer offer)
        {
            var existingOffer = await _appDbContext.offer.FindAsync(id);
            if (existingOffer == null)
            {
                return NotFound();
            }

            existingOffer.Tittleoffer = offer.Tittleoffer;
            existingOffer.Description = offer.Description;
            existingOffer.Experience = offer.Experience;
            existingOffer.Publishdate = offer.Publishdate;
            existingOffer.Requeriments = offer.Requeriments;
            existingOffer.Status = offer.Status;

            if (ModelState.IsValid)
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(existingOffer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("eliminar-convocatoria/{id}")]
        public async Task<IActionResult> DeleteOffer(int id, [FromBody] Offer offer)
        {
            var existingOffer = await _appDbContext.offer.FindAsync(id);
            if (existingOffer == null)
            {
                return NotFound();
            }

            existingOffer.Status = "Cerrada";//"Cerrada"; Poner este valor cuando cambie la base de datos.

            if (ModelState.IsValid)
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(existingOffer);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
    }
}
