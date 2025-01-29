
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


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email); // Recherche un utilisateur avec cet email
        }



        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
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
