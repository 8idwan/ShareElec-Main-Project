using System.Transactions;
using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Data;
using SherElec_Back_end.Repositories.Interfaces;

namespace SherElec_Back_end.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task CreateTransactionAsync(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetTransactionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
