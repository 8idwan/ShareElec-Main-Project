using SherElec_Back_end.Models;
using SherElec_Back_end.Repositories.Interfaces;
using SherElec_Back_end.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;
using SherElec_Back_end.DTOs.Transaction;

namespace SherElec_Back_end.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        private readonly IOffreRepository _offreRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IUserService userService, ApplicationDbContext context, IOffreRepository offreRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
            _context = context;
            _offreRepository = offreRepository;
            _mapper = mapper;
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id)
        {
            var transaction = await _transactionRepository.GetTransactionByIdAsync(id);

            if (transaction == null)
            {
                return null;
            }

            // Récupérer l'offre associée, même si l'utilisateur est supprimé
            if (transaction.OffreId.HasValue)
            {
                transaction.Offre = await _offreRepository.GetOfferById(transaction.OffreId.Value); // Utiliser GetOfferById
            }

            // Récupérer les utilisateurs (acheteur et vendeur) même s'ils sont supprimés
             transaction.Acheteur = await _userService.GetUserInfo(transaction.IdAcheteur);
             transaction.Vendeur = await _userService.GetUserInfo(transaction.IdVendeur);
           

            return transaction;
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

        public async Task<IEnumerable<Transaction>> GetTransactionsVenduesAsync(int vendeurId)
        {
            var transactions = await _transactionRepository.GetTransactionsVenduesAsync(vendeurId);
            return _mapper.Map<IEnumerable<TransactionResponseDTO>>(transactions);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAcheteesAsync(int acheteurId)
        {
            var transactions = await _transactionRepository.GetTransactionsAcheteesAsync(acheteurId);
            return _mapper.Map<IEnumerable<TransactionResponseDTO>>(transactions);
        }
    }
}