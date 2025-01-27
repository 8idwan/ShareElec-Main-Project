using System.ComponentModel.DataAnnotations;

namespace SherElec_Back_end.Models
{
    public class Offre
    {
            [Key]
            public int ID { get; set; }

            public required int UserID { get; set; }
            public User User { get; set; }
            public required double Quantite { get; set; }
            public required string Type { get; set; }
            public required double PrixKw { get; set; }
            public required bool VendDetails { get; set; }
            public required bool Status { get; set; }
            public required DateOnly Date { get; set; }
        }
    }
}
