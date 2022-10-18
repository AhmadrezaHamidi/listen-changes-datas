using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using signalRAh.Domain.Entities;

namespace signalRAh.Infrastructures
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<SickPersionEntity> SickPersionEntity { get; set; }
        public DbSet<SickPersion> SickPersion { get; set; }
        /// public DbSet<Peryode> SickPersion { get; set; }
        
        
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SickPersionEntity>()
                .HasKey(key => key.Id);

            modelBuilder.Entity<SickPersionEntity>()
                .Property(prop => prop.CreatedAt)
                .HasDefaultValueSql("getDate()");


            modelBuilder.Entity<SickPersionEntity>()
                .Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<SickPersionEntity>()
                .Property(prop => prop.PersionId)
                .IsRequired();

            modelBuilder.Entity<SickPersionEntity>()
                .Property(prop => prop.Room)
                .HasDefaultValue(null);


            modelBuilder.Entity<SickPersionEntity>()
                .Property(prop => prop.State)
                .IsRequired();

        }
    }
}