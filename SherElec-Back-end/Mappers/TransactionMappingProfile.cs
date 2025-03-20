using AutoMapper;
using SherElec_Back_end.DTOs.Transaction;
using SherElec_Back_end.Models;
using SherElec_Back_end.DTOs.Response;
using SherElec_Back_end.Services.Interfaces;

namespace SherElec_Back_end.Mappers
{
    public class TransactionMappingProfile : Profile
    {

        private readonly IUserService _userService;

        public TransactionMappingProfile(IUserService userService)
        {
            _userService = userService;

            CreateMap<Transaction, TransactionResponseDTO>()
                .ForMember(dest => dest.Acheteur, opt => opt.MapFrom(src => new UserRespenseDTO
                {
                    ID = src.Acheteur.ID,
                    nom = src.Acheteur.Nom,
                    prenom = src.Acheteur.Prenom,
                    email = src.Acheteur.Email,
                    numeroTelephone = src.Acheteur.NumeroTelephone,
                    sommeEnergie = src.Acheteur.sommeEnergie
                }))
                    .ForMember(dest => dest.Vendeur, opt => opt.MapFrom(src => new UserRespenseDTO
                    {
                        ID = src.Vendeur.ID,
                        nom = src.Vendeur.Nom,
                        prenom = src.Vendeur.Prenom,
                        email = src.Vendeur.Email,
                        numeroTelephone = src.Vendeur.NumeroTelephone,
                        sommeEnergie = src.Vendeur.sommeEnergie
                    }));
        }
    }
}