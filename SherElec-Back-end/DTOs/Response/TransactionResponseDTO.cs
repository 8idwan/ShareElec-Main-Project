using SherElec_Back_end.DTOs.Response;

namespace SherElec_Back_end.DTOs.Transaction
{
    public class TransactionResponseDTO
    {
        public int ID { get; set; }
        public int IdAcheteur { get; set; }
        public int IdVendeur { get; set; }
        public double Quantite { get; set; }
        public double PrixUnitaire { get; set; }
        public double PrixTotal { get; set; }
        public DateTime DateTransaction { get; set; }
        public int? OffreId { get; set; }

        //Ajouter les DTOs UserRespense pour acheteur et vendeur
        public UserRespenseDTO Acheteur { get; set; }

        public UserRespenseDTO Vendeur { get; set; }
    }
}