using Microsoft.EntityFrameworkCore;

namespace ConnetcSQLBase_Azure.Connection
{
    public class ConnectionToSQLBaseAzure : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ConnectionToSQLBaseAzure(DbContextOptions<ConnectionToSQLBaseAzure> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:semenserver.database.windows.net,1433;Initial Catalog=DataBase;Persist Security Info=False;User ID=SemenVlad;Password=qwe789+zxc123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
