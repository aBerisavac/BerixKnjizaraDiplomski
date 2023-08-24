using Domain;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccess
{
    public class DBKnjizaraContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=beri\mojdbserver01;Initial Catalog=BerixKnjizara;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.BookId, x.AuthorId });
            modelBuilder.Entity<BookGenre>().HasKey(x => new { x.BookId, x.GenreId });
            modelBuilder.Entity<RoleUseCase>().HasKey(x => new { x.RoleId, x.UseCaseId });

            modelBuilder.Entity<Book>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Author>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Genre>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Log>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<OrderInvoice>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Role>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<ShippingMethod>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<UseCase>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<BookPrice>().HasQueryFilter(e => !e.IsDeleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInvoice> OrderInvoices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleUseCase> RoleUseCases { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
    }
}