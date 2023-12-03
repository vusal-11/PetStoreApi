using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PetStoreApi.DbContexts;

public class UsersContext : IdentityDbContext<IdentityUser>
{
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder.UseSqlServer("Data Source=SQL5110.site4now.net;Initial Catalog=db_aa20a5_petstoredb;User Id=db_aa20a5_petstoredb_admin;Password=Asp7027472"));
    //}
}
