using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sube2.EntityApp
{
    internal class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; } // Ogrenciler tablosu için DbSet tanımı

        public DbSet<Ders> Dersler { get; set; } // Dersler tablosu için DbSet tanımı

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Integrated Security=true;Initial Catalog=OkulDBEF2;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Ogrenci entity'sinin tablo adının belirlenmesi
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            // Ogrenci entity'sinin Ad özelliğinin veritabanındaki sütununun tipi, boyutu ve zorunluluğunun belirlenmesi
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            // Ogrenci entity'sinin Soyad özelliğinin veritabanındaki sütununun tipi, boyutu ve zorunluluğunun belirlenmesi
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(40).IsRequired();
        }
    }
}
