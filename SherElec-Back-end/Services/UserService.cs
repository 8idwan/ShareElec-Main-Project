using AutoMapper;
using Microsoft.Extensions.Logging;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SherElec_Back_end.DTO;
using SherElec_Back_end.Repositories;
using SherElec_Back_end.Model;
using ShareElec.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SherElec_Back_end.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly ApplicationDbContext _context;

        public UserService(IUserRepository userRepo, IMapper mapper, ILogger<UserService> logger, ApplicationDbContext context)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
            _context = context;
        }


        public async Task ajoutCompteAsync(UserRequestDTO req)
        {
            // Vérification : L'email existe déjà ?
            var existingUser = await _userRepo.GetUserByEmailAsync(req.email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Cet email est déjà utilisé.");
            }

            var user =_mapper.Map<User>(req);

          
            await _userRepo.AddUser(user);
        }


        public async Task<UserRespenseDTO> AuthentifierUtilisateurAsync(string email, string motDePasse)
        {
            var utilisateur = await _context.Users
                                            .FirstOrDefaultAsync(u => u.Email == email); // Recherche de l'utilisateur par email

            if (utilisateur == null)
            {
                throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");
            }

            if (!BCrypt.Net.BCrypt.Verify(motDePasse, utilisateur.MotDePasse))
            {
                throw new UnauthorizedAccessException("Email ou mot de passe incorrect.");
            }

            return _mapper.Map<UserRespenseDTO>(utilisateur);
        }
        public string GenererToken(UserRespenseDTO utilisateur)
        {
        
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VotreClefSecreteTresLongueEtComplexe123!@#$%^&*"));

            // Définir les informations du JWT (claims)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, utilisateur.email),  
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),  
            new Claim("Id", utilisateur.ID.ToString())  
        };

            // Créer la signature
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // Créer l'objet JWT
            var token = new JwtSecurityToken(
                issuer: "TonNomDeDomaine",  // Émetteur du token
                audience: "TonPublic",  // Public cible
                claims: claims,  // Claims ajoutés dans le token
                expires: DateTime.UtcNow.AddHours(1),  // Expiration dans 1 heure
                signingCredentials: signingCredentials  // Signature du token
            );

            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserRespenseDTO> UpdateUserAsync(int id, UserRequestDTO requestDto)
        {
            // Récupérer l'utilisateur existant par son ID
            var user = await _userRepo.GetUserById(id);
            if (user == null)
            {
                return null; // Utilisateur non trouvé
            }

            // Vérifier si l'email a été modifié
            if (user.Email != requestDto.email)
            {
                throw new InvalidOperationException("Vous ne pouvez pas modifier votre email.");
            }

            // Mapper les autres champs du DTO vers l'utilisateur
            _mapper.Map(requestDto, user);

            // Mettre à jour l'utilisateur dans le repo
            await _userRepo.UpdateUser(user);

            // Mapper l'utilisateur mis à jour vers le DTO de réponse
            return _mapper.Map<UserRespenseDTO>(user);
        }


    }
}
