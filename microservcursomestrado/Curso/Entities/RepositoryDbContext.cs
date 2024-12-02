using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Azure.Cosmos;

namespace microservcursomestrado.Curso.Entities
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        private IConfiguration _configuration;
        public RepositoryDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
            connectionString: this._configuration["CosmosDBURL"],
            databaseName: this._configuration["CosmosDBDBName"],
            cosmosOptionsAction: options =>
            {
                options.ConnectionMode(ConnectionMode.Gateway);
                options.HttpClientFactory(() => new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                }));
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasNoDiscriminator();
            modelBuilder.Entity<Curso>()
                .ToContainer("curso");
            modelBuilder.Entity<Curso>()
                .Property(c => c.Id)
                .HasValueGenerator<GuidValueGenerator>();
            modelBuilder.Entity<Curso>()
                .HasPartitionKey(c => c.Id);
        }
    }
}
