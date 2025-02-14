namespace SherElec_Back_end.DTOs.Response
{
    public class OffreResponseDTO
    {
        public int Id { get; set; }
        public double Quantite { get; set; }
        public string Type { get; set; }
        public double PrixKw { get; set; }
        public bool VendDetails { get; set; }
        public bool Status { get; set; }

        public DateOnly Date { get; set; }

        public UserRespenseDTO? User { get; set; }

    }
}
