using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Data;
using SherElec_Back_end.Models;
using SherElec_Back_end.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SherElec_Back_end.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            try
            {
                return await _context.Transactions
                    .Include(t => t.Acheteur)
                    .Include(t => t.Vendeur)
                    .Include(t => t.Offre)
                    .FirstOrDefaultAsync(t => t.ID == id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erreur lors de la récupération de la transaction avec l'ID {id}: {ex}");
                return null;
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            try
            {
                return await _context.Transactions
                    .Include(t => t.Acheteur)
                    .Include(t => t.Vendeur)
                    .Include(t => t.Offre)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erreur lors de la récupération de toutes les transactions: {ex}");
                return new List<Transaction>();
            }
        }

        public async Task CreateTransactionAsync(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Erreur lors de la création de la transaction: {ex}");
                throw;
            }
        }
    }
}