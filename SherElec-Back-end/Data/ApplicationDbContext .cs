using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SherElec_Back_end.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    
}
