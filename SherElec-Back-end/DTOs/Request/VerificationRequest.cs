using SherElec_Back_end.DTOs;
namespace SherElec_Back_end.DTOs.Request

{
    public class VerificationRequest
    {
        public string Email { get; set; }
        public string Code { get; set; }

    }
}
