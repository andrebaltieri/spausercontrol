using SpaUserControl.Domain.Models;
using SpaUserControl.Infraestructure.Data.Map;
using System.Data.Entity;

namespace SpaUserControl.Infraestructure.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("AppConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
