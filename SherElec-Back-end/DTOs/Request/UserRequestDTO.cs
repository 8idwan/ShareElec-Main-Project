namespace SherElec_Back_end.DTOs.Request
{
    public class UserRequestDTO
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string numeroTelephone { get; set; }
        public string motDePasse { get; set; }
    }
}
