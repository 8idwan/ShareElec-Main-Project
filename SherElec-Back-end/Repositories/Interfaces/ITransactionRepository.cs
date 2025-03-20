using SherElec_Back_end.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SherElec_Back_end.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task CreateTransactionAsync(Transaction transaction);
        Task<IEnumerable<Transaction>> GetTransactionsVenduesAsync(int vendeurId);
        Task<IEnumerable<Transaction>> GetTransactionsAcheteesAsync(int acheteurId);
    }
}