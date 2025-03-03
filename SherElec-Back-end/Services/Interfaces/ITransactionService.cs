using SherElec_Back_end.Models;
using System.Threading.Tasks;

namespace SherElec_Back_end.Services.Interfaces
{
    public interface ITransactionService
    {
        Task<Transaction> GetTransactionByIdAsync(int id);
        Task<Transaction> CreateTransactionAsync(int idAcheteur, int idVendeur, double quantite, int? offreId);
    }
}