using ApiService.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiService.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){

        }

        public DbSet<Users> Users {get; set;}
        public DbSet<Rols> Rols {get; set;}
        public DbSet<RolsUser> RolsUsers {get; set;}
        
    }
}