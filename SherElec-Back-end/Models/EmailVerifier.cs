namespace SherElec_Back_end.Models
{
    public class EmailVerifier
    {
        public int Id { get; set; }  
        public string Email { get; set; }  
        public string VerificationCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
