using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Login.Models
{
	public class LoginContext:DbContext
	{
	   public LoginContext(DbContextOptions<LoginContext> options) : base(options){

       }
       public DbSet<Login> Login  { get; set; }
    //    protected override void OnModelCreating(ModelBuilder builder)
    //     {
    //         builder.Entity<login>().ToTable("login");
    //     }
	}
}