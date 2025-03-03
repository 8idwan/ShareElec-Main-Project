namespace SherElec_Back_end.DTOs.Transaction
{
    public class TransactionRequestDTO
    {
        public int IdAcheteur { get; set; }
        public int IdVendeur { get; set; }
        public double Quantite { get; set; }
        public int? OffreId { get; set; }
    }
}