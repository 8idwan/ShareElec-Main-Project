﻿using System.ComponentModel.DataAnnotations;

namespace SherElec_Back_end.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public required string Nom { get; set; }
        public required string Prenom { get; set; }
        public required string Email { get; set; }
        public required string NumeroTelephone { get; set; }
        public required string MotDePasse { get; set; }

        public double Balance { get; set; }

    }
}
