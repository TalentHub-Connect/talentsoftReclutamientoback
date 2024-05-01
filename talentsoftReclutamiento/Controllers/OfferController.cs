﻿using Microsoft.AspNetCore.Http;
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

            existingOffer.TittleOffer = offer.TittleOffer;
            existingOffer.Description = offer.Description;
            existingOffer.Status = offer.Status;
            existingOffer.Requeriments = offer.Requeriments;

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

        [HttpDelete("eliminar-convocatoria/{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _appDbContext.offer.FindAsync(id);
            if (offer == null)
            {
                return NotFound();
            }

            _appDbContext.offer.Remove(offer);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}