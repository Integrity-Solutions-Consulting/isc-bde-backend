using isc.bempleo.be.domain.Entity.Knowledges;
using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.Tools;
using isc.bempleo.be.domain.Models.Response;
using isc.bempleo.be.domain.Entity.Skills;
using isc.bempleo.be.domain.Entity.Certifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using isc.bempleo.be.domain.Entity.Experiences;

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
                entity.Property(e => e.MaritalStatus).HasColumnName("marital_status");
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");
                entity.Property(e => e.Nationality).HasColumnName("nationality");
                entity.Property(e => e.DisabilityCard).HasColumnName("disability_card");
                entity.Property(e => e.EducationLevel).HasColumnName("education_level");
                entity.Property(e => e.EducationStatus).HasColumnName("education_status");
                entity.Property(e => e.Carer).HasColumnName("career");
                entity.Property(e => e.KnowledgeList).HasColumnName("knowledge_list");
                entity.Property(e => e.ToolList).HasColumnName("tool_list");
                entity.Property(e => e.SkillList).HasColumnName("skill_list");
                entity.Property(e => e.CertificationList).HasColumnName("certification_list");
                entity.Property(e => e.AcademicInstitution).HasColumnName("academic_institution");
                entity.Property(e => e.CountryOfStudy).HasColumnName("country_of_study");
                entity.Property(e => e.EnglishLevel).HasColumnName("english_level");


                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");




            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.ToTable("Tools");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ToolID");
                entity.Property(e => e.ToolName).HasColumnName("tool_name");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<Knowledge>(entity =>
            {
                entity.ToTable("Knowledge");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("KnowledgeID");
                entity.Property(e => e.KnowledgeName).HasColumnName("knowledge_name");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<ProfileAccessCode>(entity =>
            {
                entity.ToTable("ProfileAccessCode");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ProfileAccessCodeId");
                entity.Property(e => e.Code).HasColumnName("Code");
                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skills");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("SkillID");
                entity.Property(e => e.SkillName).HasColumnName("skill_name");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("Certifications");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("CertificationID");
                entity.Property(e => e.CertificationName).HasColumnName("certification_name");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });


            modelBuilder.Entity<domain.Entity.Documents.Document>(entity =>
            {
                entity.ToTable("Documents");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("DocumentID");
                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
                entity.Property(e => e.Bucket).HasColumnName("bucket");
                entity.Property(e => e.ObjectName).HasColumnName("object_name");
                entity.Property(e => e.DocumentName).HasColumnName("document_name");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");

                entity.HasOne(e => e.Profile).WithMany().HasForeignKey(e => e.ProfileId);


            });


            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Profile> Profiles { get; set; }    
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<ProfileAccessCode> ProfileAccessCodes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certification> Certifications { get; set; }

        public DbSet<domain.Entity.Documents.Document> Documents { get; set; }


    }
}
