
using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Model;
using SherElec_Back_end.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShareElec.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            // Hash du mot de passe avant de l'ajouter
            user.MotDePasse = BCrypt.Net.BCrypt.HashPassword(user.MotDePasse);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

  

        public async Task UpdateUser(User user)
        {
            // Vérifier si l'utilisateur existe
            var existingUser = await _context.Users.FindAsync(user.ID);
            if (existingUser == null)
                return;

            // Mise à jour des champs
            existingUser.Prenom = user.Prenom;
            existingUser.Nom = user.Nom;
            existingUser.NumeroTelephone = user.NumeroTelephone;
            existingUser.MotDePasse = BCrypt.Net.BCrypt.HashPassword(user.MotDePasse);

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
