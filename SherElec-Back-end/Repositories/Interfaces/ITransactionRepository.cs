using System.Transactions;

namespace SherElec_Back_end.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
        Task CreateTransactionAsync(Transaction transaction);
    }
}
