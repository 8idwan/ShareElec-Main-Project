namespace SherElec_Back_end.DTOs.Response
{
  
        public class UserRespenseDTO
        {
            public int ID { get; set; }
            public string nom { get; set; }
            public string prenom { get; set; }
            public string email { get; set; }
            public string numeroTelephone { get; set; }
            public double sommeEnergie { get; set; }

        }
    }