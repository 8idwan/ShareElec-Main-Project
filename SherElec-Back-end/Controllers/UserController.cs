using Microsoft.AspNetCore.Mvc;
using SherElec_Back_end.DTO;
using SherElec_Back_end.Services;

namespace SherElec_Back_end.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> ajoutCompte([FromBody] UserRequestDTO userRequestDTO)
        {
            if (userRequestDTO == null)
            {
                return BadRequest("Les données de l'utilisateur sont invalides.");
            }

            try
            {
                await _userService.ajoutCompteAsync(userRequestDTO);
                return CreatedAtAction(
                    nameof(ajoutCompte),
                    new { message = "Utilisateur créé avec succès" }
                );
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Une erreur est survenue.", details = ex.Message });
            }
        }
    }
}
