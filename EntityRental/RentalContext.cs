using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityRental.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityRental
{
    internal class RentalContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=rental;Username=postgres;Password=superpippo;");
            optionsBuilder.UseNpgsql(AppConfig.GetConnectionString());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Film>()
            //     .HasKey(f => f.Id);
            // modelBuilder.Entity<Film>()
            //     .Property(f => f.Id)
            //     .UseIdentityColumn();
            // modelBuilder.Entity<Film>()
            //     .Property(f => f.Title)
            //     .IsRequired()    
            //     .HasMaxLength(200);
            // modelBuilder.Entity<Film>()
            //     .Property(f => f.Description)
            //     .HasMaxLength(200);
            // modelBuilder.Entity<Film>()
            //     .Property(f => f.ReleaseYear)
            //     .IsRequired();
            // modelBuilder.Entity<Film>()
            //     .Property(f => f.RentalDuration)
            //     .IsRequired();


            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(f => f.Title).HasMaxLength(200).HasColumnType("varchar(200)");
                entity.Property(f => f.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(f => f.LanguageId);
                entity.Property(f => f.LanguageId).ValueGeneratedOnAdd();
                entity.Property(f => f.Name).HasMaxLength(200);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(f => f.CategoryId);
                entity.Property(f => f.CategoryId).ValueGeneratedOnAdd();
                entity.Property(f => f.Name).HasMaxLength(200);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Film_category>(entity =>
            {
                entity.HasKey(f => new { f.FilmId, f.CategoryId });
                entity.HasOne<Film>().WithMany().HasForeignKey(f => f.FilmId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Category>().WithMany().HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(f => f.ActorId);
                entity.Property(f => f.ActorId).ValueGeneratedOnAdd();
                entity.Property(f => f.FirstName).HasMaxLength(200);
                entity.Property(f => f.LastName).HasMaxLength(200);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Film_actor>(entity =>
            {
                entity.HasKey(f => new { f.FilmId, f.ActorId });
                entity.HasOne<Film>().WithMany().HasForeignKey(f => f.FilmId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Category>().WithMany().HasForeignKey(f => f.ActorId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(f => f.InventoryId);
                entity.Property(f => f.InventoryId).ValueGeneratedOnAdd();
                entity.HasOne<Film>().WithMany().HasForeignKey(f => f.FilmId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Store>().WithMany().HasForeignKey(f => f.StoreId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(f => f.RentalId);
                entity.Property(f => f.RentalId).ValueGeneratedOnAdd();
                entity.HasOne<Inventory>().WithMany().HasForeignKey(f => f.InventoryId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Customer>().WithMany().HasForeignKey(f => f.CustomerId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Staff>().WithMany().HasForeignKey(f => f.StaffId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(f => f.PaymentId);
                entity.Property(f => f.PaymentId).ValueGeneratedOnAdd();
                entity.HasOne<Customer>().WithMany().HasForeignKey(f => f.CustomerId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Staff>().WithMany().HasForeignKey(f => f.StaffId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Rental>().WithMany().HasForeignKey(f => f.RentalId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(f => f.StaffId);
                entity.Property(f => f.StaffId).ValueGeneratedOnAdd();
                entity.Property(f => f.FirstName).HasMaxLength(200);
                entity.Property(f => f.LastName).HasMaxLength(200);
                entity.HasOne<Address>().WithMany().HasForeignKey(f => f.AddressId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.Email).HasMaxLength(200);
                entity.HasOne<Store>().WithMany().HasForeignKey(f => f.StoreId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(f => f.CustomerId);
                entity.Property(f => f.CustomerId).ValueGeneratedOnAdd();
                entity.HasOne<Store>().WithMany().HasForeignKey(f => f.StoreId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.FirstName).HasMaxLength(200);
                entity.Property(f => f.LastName).HasMaxLength(200);
                entity.Property(f => f.Email).HasMaxLength(200);
                entity.HasOne<Address>().WithMany().HasForeignKey(f => f.AddressId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(f => f.AddressId);
                entity.Property(f => f.AddressId).ValueGeneratedOnAdd();
                entity.Property(f => f.AddressLine1).HasMaxLength(200);
                entity.Property(f => f.AddressLine2).HasMaxLength(200);
                entity.Property(f => f.District).HasMaxLength(200);
                entity.HasOne<City>().WithMany().HasForeignKey(f => f.CityId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.PostalCode).HasMaxLength(20);
                entity.Property(f => f.Phone).HasMaxLength(20);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(f => f.CityId);
                entity.Property(f => f.CityId).ValueGeneratedOnAdd();
                entity.Property(f => f.CityName).HasMaxLength(200);
                entity.HasOne<Country>().WithMany().HasForeignKey(f => f.CountryId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(f => f.CountryId);
                entity.Property(f => f.CountryId).ValueGeneratedOnAdd();
                entity.Property(f => f.CountryName).HasMaxLength(200);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(f => f.StoreId);
                entity.Property(f => f.StoreId).ValueGeneratedOnAdd();
                entity.HasOne<Address>().WithMany().HasForeignKey(f => f.AddressId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne<Staff>().WithMany().HasForeignKey(f => f.ManagerStaffId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(f => f.LastUpdate).HasMaxLength(200);
            });
        }

    }
}

