using Amazon.S3;
using isc.bempleo.be.domain.Entity.Catalogs;
using isc.bempleo.be.domain.Entity.Experiences;
using isc.bempleo.be.domain.Entity.ProfileAccessCodes;
using isc.bempleo.be.domain.Entity.Profiles;
using isc.bempleo.be.domain.Entity.ProfileVacancies;
using isc.bempleo.be.domain.Models.Response;
using isc.bempleo.be.domain.Models.Response.Catalogs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
                entity.Property(e => e.MaritalStatusId).HasColumnName("MaritalStatusID");
                entity.Property(e => e.FirstName).HasColumnName("first_name");
                entity.Property(e => e.LastName).HasColumnName("last_name");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.IdentificationNumber).HasColumnName("identification_number");
                entity.Property(e => e.Phone).HasColumnName("phone");
                entity.Property(e => e.Address).HasColumnName("address");
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");
                entity.Property(e => e.Nationality).HasColumnName("nationality");
                entity.Property(e => e.DisabilityCard).HasColumnName("disability_card");
                entity.Property(e => e.EducationLevel).HasColumnName("education_level");
                entity.Property(e => e.EducationStatus).HasColumnName("education_status");
                entity.Property(e => e.KnowledgeList).HasColumnName("knowledge_list");
                entity.Property(e => e.ToolList).HasColumnName("tool_list");
                entity.Property(e => e.SkillList).HasColumnName("skill_list");
                entity.Property(e => e.CertificationList).HasColumnName("certification_list");
                entity.Property(e => e.CareerList).HasColumnName("career_list");
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

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experiences");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ExperienceID");
                entity.Property(e => e.CompanyName).HasColumnName("company_name");
                entity.Property(e => e.PositionHeld).HasColumnName("position_held");
                entity.Property(e => e.ExperienceTime).HasColumnName("experience_time");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");

                entity.HasOne(e => e.Profile).WithMany().HasForeignKey(e => e.ProfileId);
            });

            modelBuilder.Entity<domain.Entity.Documents.Document>(entity =>
            {
                entity.ToTable("Documents");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("DocumentID");
                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");
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

            modelBuilder.Entity<MaritalStatu>(entity =>
            {
                entity.ToTable("MaritalStatus");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("MaritalStatusID");
                entity.Property(e => e.MaritalStatusName).HasColumnName("maritalstatus_name");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<Career>(entity =>
            {
                entity.ToTable("Careers");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("CareerID");
                entity.Property(e => e.CareerName).HasColumnName("career_name");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<Vacancy>(entity =>
            {
                entity.ToTable("Vacancies");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("VacancyID");
                entity.Property(e => e.VacancyTitle).HasColumnName("vacancy_title").IsRequired();
                entity.Property(e => e.PositionDescription).HasColumnName("position_description").IsRequired();
                entity.Property(e => e.Requirements).HasColumnName("requirements");
                entity.Property(e => e.TerminationDate).HasColumnName("termination_date");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<ApplicationStatu>(entity =>
            {
                entity.ToTable("ApplicationStatus");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("ApplicationStatusID");
                entity.Property(e => e.StatusName).HasColumnName("status_name");

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");
            });

            modelBuilder.Entity<ProfileVacancy>(entity =>
            {
                entity.ToTable("ProfileVacancies");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ProfileVacancyID");
                entity.Property(e => e.ProfileId).HasColumnName("ProfileID").IsRequired();
                entity.Property(e => e.VacancyId).HasColumnName("VacancyID").IsRequired();
                entity.Property(e => e.ApplicationDate).HasColumnName("application_date").IsRequired();
                entity.Property(e => e.ApplicationStatusId).HasColumnName("ApplicationStatusID").IsRequired();

                entity.Property(e => e.Status).HasColumnName("status");
                entity.Property(e => e.CreationUser).HasColumnName("creation_user");
                entity.Property(e => e.ModificationUser).HasColumnName("modification_user");
                entity.Property(e => e.CreationDate).HasColumnName("creation_date");
                entity.Property(e => e.ModificationDate).HasColumnName("modification_date");
                entity.Property(e => e.CreationIp).HasColumnName("creation_ip");
                entity.Property(e => e.ModificationIp).HasColumnName("modification_ip");

                entity.HasOne(e => e.Profile).WithMany().HasForeignKey(e => e.ProfileId);
                entity.HasOne(e => e.Vacancy).WithMany().HasForeignKey(e => e.VacancyId);
                entity.HasOne(pv => pv.ApplicationStatus).WithMany().HasForeignKey(pv => pv.ApplicationStatusId);
            });

            modelBuilder.Entity<StudyStatuResponse>().HasNoKey().ToView(null);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Profile> Profiles { get; set; }    
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<ProfileAccessCode> ProfileAccessCodes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<MaritalStatu> MaritalStatus { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<ApplicationStatu> ApplicationStatus { get; set; }
        public DbSet<ProfileVacancy> ProfileVacancies { get; set; }
        public DbSet<domain.Entity.Documents.Document> Documents { get; set; }

        }
}
