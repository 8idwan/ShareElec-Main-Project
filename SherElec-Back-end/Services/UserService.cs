using AutoMapper;
using Microsoft.Extensions.Logging;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SherElec_Back_end.DTO;
using SherElec_Back_end.Repositories;
using SherElec_Back_end.Model;

namespace SherElec_Back_end.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepo, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task ajoutCompteAsync(UserRequestDTO req)
        {
            // Vérification : L'email existe déjà ?
            var existingUser = await _userRepo.GetUserByEmail(req.email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Cet email est déjà utilisé.");
            }

            // Mapper le DTO en entité User
            var user =_mapper.Map<User>(req);

            // Ajouter l'utilisateur dans la base de données
            await _userRepo.AddUser(user);
        }

    }
}
