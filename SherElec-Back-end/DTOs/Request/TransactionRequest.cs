namespace SherElec_Back_end.DTOs.Request
{
    public class TransactionRequest
    {
        public int OffreId { get; set; } // ID de l'offre
        public int Amount { get; set; }  // Montant total en euros
        public int Quantite { get; set; } // Quantité achetée
        public int AcheteurId { get; set; } // ID de l'acheteur
        public int VendeurId { get; set; } // ID du vendeur
    }
}
