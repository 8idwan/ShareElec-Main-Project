using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var utilisateur = await _userService.AuthentifierUtilisateurAsync(request.Email, request.Password);
                var token = _userService.GenererToken(utilisateur);
                return Ok(new
                {
                    Token = token,
                    Utilisateur = utilisateur // Retourne le DTO pour afficher ces information 
                });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [Authorize]
        [HttpPut("maj/{id}")]
        public async Task<ActionResult<UserRespenseDTO>> UpdateUser(int id, [FromBody] UserRequestDTO userRequestDto)
        {
            if (userRequestDto == null)
            {
                return BadRequest("Les données de l'utilisateur sont invalides.");
            }

            // Récupérer l'ID utilisateur à partir du jeton JWT
            var userIdFromToken = User.FindFirst("Id")?.Value;

            // Comparer les IDs : si l'ID dans le jeton ne correspond pas à l'ID dans l'URL, refuser la modification
            if (userIdFromToken != id.ToString())
            {
                return Unauthorized("Vous ne pouvez modifier que votre propre compte.");
            }

            // Appeler le service pour mettre à jour l'utilisateur
            var updatedUser = await _userService.UpdateUserAsync(id, userRequestDto);

           
            if (updatedUser == null)
            {
                return NotFound($"Utilisateur avec l'ID {id} non trouvé.");
            }

            
            return Ok(updatedUser);
        }




    }
}
