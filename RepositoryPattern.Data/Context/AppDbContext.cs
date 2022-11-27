using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Configurations;
using RepositoryPattern.Domain.Entities;


namespace RepositoryPattern.Data.Context // Veri tabanı bağlantısını sağlayacak context.
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }                
        // DbSet<class>: DbSet içerisinde verdiğimiz class'ı veri tabanında tablo yapar. 
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.ApplyConfiguration(new ProductConfiguration()); // Tablo için oluşturduğumuz configure dosyalarını veri tabanına uygular. 
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // Birden fazla configuration dosyası için. DbContext'deki tüm table configurationları bulup register eder.
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=PaparaDb; Trusted_Connection=True;");
        //}
    }
}
