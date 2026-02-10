using Microsoft.EntityFrameworkCore;
using MoneyFlow.Entities;

namespace MoneyFlow.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Service> Service{ get; set; }
        public DbSet<Transaction> Transaction{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuramos la entidad User
            modelBuilder.Entity<User>(e => {
                e.HasKey("UserId");
                e.Property("UserId").ValueGeneratedOnAdd();

                e.HasData(
                    new User() { UserId = 1 , FullName = "Luis David", Email = "cusiluis04@gmail.com", Password = "123456"}
                    );
            });

            // Configuramos la entidad Service
            modelBuilder.Entity<Service>(e => {
                e.HasKey("ServiceId");
                e.Property("ServiceId").ValueGeneratedOnAdd();

                e.HasOne(e => e.User).WithMany(u => u.Services).HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuramos la entidad Transacción 
            modelBuilder.Entity<Transaction>(t =>
            {
                t.HasKey("TransactionId");
                t.Property("TransactionId").ValueGeneratedOnAdd();
                t.Property("Date").HasColumnType("date");
                t.Property("TotalAmount").HasColumnType("decimal(10,2)");


                t.HasOne(t => t.Service).WithMany().HasForeignKey(t => t.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);

                t.HasOne(t => t.User).WithMany(u => u.Transactions).HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                
            });
            
        }
    }
}
