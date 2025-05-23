﻿using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Models;

namespace SherElec_Back_end.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Offre> Offers { get; set; }
    }
}
