using SherElec_Back_end.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static SherElec_Back_end.Controllers.PaymentsController;

namespace SherElec_Back_end.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task CreateTransactionAsync(PaymentSuccessRequest request); // modifier la requete 
        Task<IEnumerable<Transaction>> GetTransactionsVenduesAsync(int vendeurId);
        Task<IEnumerable<Transaction>> GetTransactionsAcheteesAsync(int acheteurId);
    }
}