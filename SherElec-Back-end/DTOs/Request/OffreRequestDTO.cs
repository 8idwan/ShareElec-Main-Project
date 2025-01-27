namespace SherElec_Back_end.DTOs.Request
{
    public class OffreRequestDTO
    {
        public int Quantite { get; set; }

        public string Type { get; set; }

        public bool VendDetails { get; set; }
        public double PrixKw { get; set; }
        public DateOnly Date { get; set; }

        public bool Status { get; set; }

        public int Userid { get; set; }
    }
}
