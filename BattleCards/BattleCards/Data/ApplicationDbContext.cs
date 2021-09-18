namespace BattleCards.Data
{
    using BattleCards.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserCard>()
                .HasKey(x => new {x.UserId, x.CardId});
        }

        public DbSet<Card> Cards {get;set;}
        public DbSet<User> Users { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
    }
}
