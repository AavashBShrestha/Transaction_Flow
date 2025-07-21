using Microsoft.EntityFrameworkCore;

namespace Transaction_Flow.Model
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<DebtModel> Debts { get; set; }

        private readonly string DbPath;

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            DbPath = Path.Combine(@"D:\Study_Material\Transaction_Flow\Database\", "app.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Filename={DbPath}");
    }
}
