namespace SherElec_Back_end.Models
{
    public class EmailVerifier
    {
        public int Id { get; set; }

        public string VerificationCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public required string NumeroTelephone { get; set; }
        public required string MotDePasse { get; set; }
        public double sommeEnergie { get; set; }
    }

}