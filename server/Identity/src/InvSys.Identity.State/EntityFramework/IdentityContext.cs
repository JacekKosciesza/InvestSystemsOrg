using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InvSys.Identity.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using OpenIddict;

namespace InvSys.Identity.State.EntityFramework
{
    public class IdentityContext : OpenIddictDbContext // IdentityDbContext<User>
    {
        private readonly IConfigurationRoot _config;

        public IdentityContext() { }

        public DbSet<User> ApplicationUsers {get; set;}

        public IdentityContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Identity;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer(_config["ConnectionStrings:IdentityContextConnection"]);
        }
    }
}
