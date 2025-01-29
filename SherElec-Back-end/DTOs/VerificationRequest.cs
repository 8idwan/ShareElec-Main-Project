using SherElec_Back_end.DTO;

namespace SherElec_Back_end.DTOs
{
    public class VerificationRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public UserRequestDTO UserData { get; set; }
    }
}
