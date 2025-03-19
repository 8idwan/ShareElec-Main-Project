﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SherElec_Back_end.DTOs.Request;
using SherElec_Back_end.DTOs.Response;
using SherElec_Back_end.Services.Interfaces;

namespace SherElec_Back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class OffreController : Controller
    {

        private readonly IOffreService _offreService;


        public OffreController(IOffreService offreService)
        {
            _offreService = offreService;
        }

        // POST api/offre
        [HttpPost("add")]
        public async Task<ActionResult<OffreResponseDTO>> CreateOffer([FromBody] OffreRequestDTO offerRequestDto)
        {
            if (offerRequestDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var offre = await _offreService.CreateOfferAsync(offerRequestDto);

            return CreatedAtAction(nameof(GetOfferById), new { id = offre.Id }, offre);
        }
        // GET api/offres
        [HttpGet("offres")]
        public async Task<ActionResult<IEnumerable<OffreResponseDTO>>> GetAllOffers()
        {
            var offres = await _offreService.GetAllOffersAsync();
            return Ok(offres);
        }

        [HttpGet("offres/user/{userId}")]
        public async Task<ActionResult<IEnumerable<MesOffreResponseDTO>>> GetOffresByUserId(int userId)
        {
            try
            {
                var offres = await _offreService.GetOffresByUserIdAsync(userId);

                if (offres == null || !offres.Any())
                {
                    return NotFound($"Aucune offre trouvée pour l'utilisateur {userId}.");
                }

                return Ok(offres);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
            }
        }


        // GET api/offre/{id}
        [HttpGet("offres/{id}")]
        public async Task<ActionResult<OffreResponseDTO>> GetOfferById(int id)
        {
            var offre = await _offreService.GetOfferByIdAsync(id);
            if (offre == null)
            {
                return NotFound($"Offer with ID {id} not found.");
            }
            return Ok(offre);
        }

        // PUT api/offre/{id}
        [HttpPut("update/{id}")]
        public async Task<ActionResult<OffreResponseDTO>> UpdateOffre(int id, [FromBody] OffreRequestDTO offerRequestDto)
        {
            if (offerRequestDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var updatedOffer = await _offreService.UpdateOfferAsync(id, offerRequestDto);
            if (updatedOffer == null)
            {
                return NotFound($"Offer with ID {id} not found.");
            }

            return Ok(updatedOffer);
        }


        // DELETE api/offre/{id}
        [HttpDelete("delete/{id}")]
        public async Task<bool> DeleteOffre(int id)
        {
            var success = await _offreService.DeleteOfferAsync(id);
            if (!success)
            {
                return success;
            }
            return success;
        }





    }
}