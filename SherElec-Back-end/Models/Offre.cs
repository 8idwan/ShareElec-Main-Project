using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SherElec_Back_end.Models
{
    public class Offre
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [Required]
        public double Quantite { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public double PrixKw { get; set; }

        [Required]
        public bool VendDetails { get; set; }

        [Required]
        public DateOnly Date { get; set; }
    }
    }

