namespace SherElec_Back_end.DTOs.Response
{
    public class UserResponseDTO
    {
        public int IdUser { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NumeroTelephone { get; set; }

        public double Balance { get; set; }

        public string Email { get; set; }
    }
}
