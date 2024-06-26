﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors; // Asegúrate de importar este espacio de nombres
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using talentsoftReclutamiento.Data;
using talentsoftReclutamiento.Models;

namespace talentsoftReclutamiento.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CandidateController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        [HttpGet("obtener-aspirantes")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen
        public async Task<IActionResult> getAllCandidates()
        {
            var allCandidates = await _appDbContext.candidate.ToListAsync();
            return Ok(allCandidates);
        }


        [HttpGet("obtener-aspirante/{id}")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _appDbContext.candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPost("agregar-aspirante")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> AddCandidate([FromBody] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.candidate.Add(candidate);
                await _appDbContext.SaveChangesAsync();

                return Ok(candidate);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("actualizar-aspirante/{id}")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> UpdateCandidate(int id, [FromBody] Candidate candidate)
        {
            var existingCandidate = await _appDbContext.candidate.FindAsync(id);
            if (existingCandidate == null)
            {
                return NotFound();
            }

            existingCandidate.Name = candidate.Name;
            existingCandidate.Surname = candidate.Surname;
            existingCandidate.OfferId = candidate.OfferId;
            existingCandidate.Phonenumber = candidate.Phonenumber;
            existingCandidate.CvId = candidate.CvId;
            existingCandidate.Candidatestatusid = candidate.Candidatestatusid;

            if (ModelState.IsValid)
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(existingCandidate);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("eliminar-aspirante/{id}")]
        [EnableCors("AllowAnyOrigin")] // Habilitar CORS para cualquier origen

        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _appDbContext.candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _appDbContext.candidate.Remove(candidate);

            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
