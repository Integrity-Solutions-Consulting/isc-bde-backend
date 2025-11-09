using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isc.bempleo.be.infrastructure.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Profile>(entity =>
            {


                entity.ToTable("Profiles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ProfileID");
                entity.Property(e => e.GenderId).HasColumnName("GenderID");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.IdentificationNumber).HasColumnName("identification_number");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.GenderId).HasColumnName("marital_status");
                entity.Property(e => e.GenderId).HasColumnName("birth_date");
                entity.Property(e => e.GenderId).HasColumnName("nationality");
                entity.Property(e => e.GenderId).HasColumnName("disability_card");
                entity.Property(e => e.GenderId).HasColumnName("education_level");
                entity.Property(e => e.GenderId).HasColumnName("education_status");
                entity.Property(e => e.GenderId).HasColumnName("career");
                entity.Property(e => e.GenderId).HasColumnName("academic_institution");
                entity.Property(e => e.GenderId).HasColumnName("country_of_study");
                entity.Property(e => e.GenderId).HasColumnName("english_level");


                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");

            });


            modelBuilder.Entity<ProjectionHoursProjectResponse>().HasNoKey();


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Profile> Profiles { get; set; }

    }
}
