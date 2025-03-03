using SherElec_Back_end.Data;
using SherElec_Back_end.Models;
using SherElec_Back_end.Repositories.Interfaces;
using SherElec_Back_end.Services.Interfaces;

namespace SherElec_Back_end.Services
{
    public class TransactionService : ITransactionService


    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        private readonly IOffreRepository _offreRepository;

        public TransactionService(ITransactionRepository transactionRepository, IUserService userService, ApplicationDbContext context, IOffreRepository offreRepository)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
            _context = context;
            _offreRepository = offreRepository;
        }
        public async Task<Transaction> CreateTransactionAsync(int idAcheteur, int idVendeur, double quantite, int? offreId)
        {
            //Calculer le prix 
            var prixUnitaire = 1.5;
            var prixTotal = quantite * prixUnitaire;

            var transaction = new Transaction
            {
                IdAcheteur = idAcheteur,
                IdVendeur = idVendeur,
                Quantite = quantite,
                PrixUnitaire = prixUnitaire,
                PrixTotal = prixTotal,
                DateTransaction = DateTime.UtcNow,
                OffreId = offreId
            };

            await _transactionRepository.CreateTransactionAsync(transaction);
            return transaction;
        }        
        

        public Task<Transaction> GetTransactionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
