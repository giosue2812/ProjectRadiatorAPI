using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectRadiator.Models
{
    public partial class ProjectRadiatorContext : DbContext
    {
        public ProjectRadiatorContext()
        {
        }

        public ProjectRadiatorContext(DbContextOptions<ProjectRadiatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContactCarnet> ContactCarnet { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<FollowPeople> FollowPeople { get; set; }
        public virtual DbSet<FollowTypeFollow> FollowTypeFollow { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Logger> Logger { get; set; }
        public virtual DbSet<Metting> Metting { get; set; }
        public virtual DbSet<MettingPeople> MettingPeople { get; set; }
        public virtual DbSet<Milestones> Milestones { get; set; }
        public virtual DbSet<MilestonesProject> MilestonesProject { get; set; }
        public virtual DbSet<MilestonesType> MilestonesType { get; set; }
        public virtual DbSet<MilestonesTypeMilestones> MilestonesTypeMilestones { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PeopleJob> PeopleJob { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectPeople> ProjectPeople { get; set; }
        public virtual DbSet<ProjectStage> ProjectStage { get; set; }
        public virtual DbSet<SecurityGroupe> SecurityGroupe { get; set; }
        public virtual DbSet<SecurityGroupeRole> SecurityGroupeRole { get; set; }
        public virtual DbSet<SecurityGroupeUser> SecurityGroupeUser { get; set; }
        public virtual DbSet<SecurityRole> SecurityRole { get; set; }
        public virtual DbSet<SecurityUserRole> SecurityUserRole { get; set; }
        public virtual DbSet<Society> Society { get; set; }
        public virtual DbSet<Stages> Stages { get; set; }
        public virtual DbSet<StagesTypeStages> StagesTypeStages { get; set; }
        public virtual DbSet<TypeFollow> TypeFollow { get; set; }
        public virtual DbSet<TypeStages> TypeStages { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Directive #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Data Source=desktop-pgp6817;Database=ProjectRadiator;Trusted_Connection=True;");
#pragma warning restore CS1030 // Directive #warning
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactCarnet>(entity =>
            {
                entity.Property(e => e.AdressCity).IsUnicode(false);

                entity.Property(e => e.AdressCountry).IsUnicode(false);

                entity.Property(e => e.AdressStreet).IsUnicode(false);

                entity.Property(e => e.CrationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);
            });

            modelBuilder.Entity<Follow>(entity =>
            {
                entity.HasKey(e => e.IdFollow)
                    .HasName("Follow_PK");

                entity.Property(e => e.CommentCustomer).IsUnicode(false);

                entity.Property(e => e.CommentDev).IsUnicode(false);

                entity.Property(e => e.DateFollow).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Follow)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Follow_Project_FK");
            });

            modelBuilder.Entity<FollowPeople>(entity =>
            {
                entity.HasKey(e => new { e.IdPeople, e.IdFollow })
                    .HasName("FollowPeople_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdFollowNavigation)
                    .WithMany(p => p.FollowPeople)
                    .HasForeignKey(d => d.IdFollow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FollowPeople_Follow_FK");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.FollowPeople)
                    .HasForeignKey(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FollowPeople_People_FK");
            });

            modelBuilder.Entity<FollowTypeFollow>(entity =>
            {
                entity.HasKey(e => new { e.IdFollow, e.IdTypeFollow })
                    .HasName("FollowTypeComment_PK");

                entity.HasOne(d => d.IdFollowNavigation)
                    .WithMany(p => p.FollowTypeFollow)
                    .HasForeignKey(d => d.IdFollow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FollowTypeComment_Follow_FK");

                entity.HasOne(d => d.IdTypeFollowNavigation)
                    .WithMany(p => p.FollowTypeFollow)
                    .HasForeignKey(d => d.IdTypeFollow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FollowTypeComment_TypeFollow_FK");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.IdJob)
                    .HasName("Job_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Label).IsUnicode(false);
            });

            modelBuilder.Entity<Logger>(entity =>
            {
                entity.HasKey(e => e.IdLog)
                    .HasName("Loh_PK");

                entity.Property(e => e.DateLog).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.TypeLog).IsUnicode(false);
            });

            modelBuilder.Entity<Metting>(entity =>
            {
                entity.HasKey(e => e.IdMetting)
                    .HasName("Metting_PK");

                entity.Property(e => e.MettingDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MettingResult).IsUnicode(false);

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.Metting)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Metting_Project_FK");
            });

            modelBuilder.Entity<MettingPeople>(entity =>
            {
                entity.HasKey(e => new { e.IdMetting, e.IdPeople })
                    .HasName("MettingPeople_PK");

                entity.HasOne(d => d.IdMettingNavigation)
                    .WithMany(p => p.MettingPeople)
                    .HasForeignKey(d => d.IdMetting)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MettingPeople_Metting_FK");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.MettingPeople)
                    .HasForeignKey(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MettingPeople_People_FK");
            });

            modelBuilder.Entity<Milestones>(entity =>
            {
                entity.HasKey(e => e.IdMilestones)
                    .HasName("Milestones_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MilestonesProject>(entity =>
            {
                entity.HasKey(e => new { e.IdMilestones, e.IdProject })
                    .HasName("MilestonesProject_PK");

                entity.HasOne(d => d.IdMilestonesNavigation)
                    .WithMany(p => p.MilestonesProject)
                    .HasForeignKey(d => d.IdMilestones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MilestonesProject_Milestones_FK");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.MilestonesProject)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MilestonesProject_Project_FK");
            });

            modelBuilder.Entity<MilestonesType>(entity =>
            {
                entity.HasKey(e => e.IdTypeMilestones)
                    .HasName("MilestonesType_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeMilestones).IsUnicode(false);
            });

            modelBuilder.Entity<MilestonesTypeMilestones>(entity =>
            {
                entity.HasKey(e => new { e.IdTypeMilestones, e.IdMilestones })
                    .HasName("MilestonesTypeMilestones_PK");

                entity.HasOne(d => d.IdMilestonesNavigation)
                    .WithMany(p => p.MilestonesTypeMilestones)
                    .HasForeignKey(d => d.IdMilestones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MilestonesTypeMilestones_Milestones_FK");

                entity.HasOne(d => d.IdTypeMilestonesNavigation)
                    .WithMany(p => p.MilestonesTypeMilestones)
                    .HasForeignKey(d => d.IdTypeMilestones)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MilestonesTypeMilestones_MilestonesType_FK");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.IdPeople)
                    .HasName("Prople_PK");

                entity.Property(e => e.IdPeople).ValueGeneratedNever();

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithOne(p => p.People)
                    .HasForeignKey<People>(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("People_ContactCarnet_FK");

                entity.HasOne(d => d.IdSocietyNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.IdSociety)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("People_Society_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("People_Users_FK");
            });

            modelBuilder.Entity<PeopleJob>(entity =>
            {
                entity.HasKey(e => new { e.IdPeople, e.IdJob })
                    .HasName("PeopleJob_PK");

                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdJobNavigation)
                    .WithMany(p => p.PeopleJob)
                    .HasForeignKey(d => d.IdJob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PeopleJob_Job_FK");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.PeopleJob)
                    .HasForeignKey(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PeopleJob_People_FK");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.IdProject)
                    .HasName("Project_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.HasOne(d => d.IdSocietyNavigation)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.IdSociety)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Project_Society_FK");
            });

            modelBuilder.Entity<ProjectPeople>(entity =>
            {
                entity.HasKey(e => new { e.IdPeople, e.IdProject })
                    .HasName("ProjectPeople_PK");

                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.ProjectPeople)
                    .HasForeignKey(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProjectPeople_People_FK");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectPeople)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProjectPeople_Project_FK");
            });

            modelBuilder.Entity<ProjectStage>(entity =>
            {
                entity.HasKey(e => new { e.IdProject, e.IdStage })
                    .HasName("ProjectStage_PK");

                entity.HasOne(d => d.IdProjectNavigation)
                    .WithMany(p => p.ProjectStage)
                    .HasForeignKey(d => d.IdProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProjectStage_Project_FK");

                entity.HasOne(d => d.IdStageNavigation)
                    .WithMany(p => p.ProjectStage)
                    .HasForeignKey(d => d.IdStage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Project_Stages_FK");
            });

            modelBuilder.Entity<SecurityGroupe>(entity =>
            {
                entity.HasKey(e => e.IdGroupe)
                    .HasName("SecurityGroupe_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Label).IsUnicode(false);
            });

            modelBuilder.Entity<SecurityGroupeRole>(entity =>
            {
                entity.HasKey(e => new { e.IdRole, e.IdGroupe })
                    .HasName("SecurityGroupeRole_PK");

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany(p => p.SecurityGroupeRole)
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SecurityGroupeRole_Groupe_FK");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.SecurityGroupeRole)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SecurityGroupeRole_Role_FK");
            });

            modelBuilder.Entity<SecurityGroupeUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.IdGroupe })
                    .HasName("SecurityGroupeUser_PK");

                entity.HasOne(d => d.IdGroupeNavigation)
                    .WithMany(p => p.SecurityGroupeUser)
                    .HasForeignKey(d => d.IdGroupe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SecurityGroupeUser_Groupe_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SecurityGroupeUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SecurityGroupeUser_User_FK");
            });

            modelBuilder.Entity<SecurityRole>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("SecurityRole_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Label).IsUnicode(false);
            });

            modelBuilder.Entity<SecurityUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.IdRole })
                    .HasName("SecurityUserRole_PK");

                entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.SecurityUserRole)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SecurityUserRole_Role_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SecurityUserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SecurityUserRole_User_FK");
            });

            modelBuilder.Entity<Society>(entity =>
            {
                entity.HasKey(e => e.IdSociety)
                    .HasName("Society_PK");

                entity.Property(e => e.IdSociety).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdSocietyNavigation)
                    .WithOne(p => p.Society)
                    .HasForeignKey<Society>(d => d.IdSociety)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Society_ContactCarnet_FK");
            });

            modelBuilder.Entity<Stages>(entity =>
            {
                entity.HasKey(e => e.IdStage)
                    .HasName("Stages_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdPeopleNavigation)
                    .WithMany(p => p.Stages)
                    .HasForeignKey(d => d.IdPeople)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stages_People_FK");
            });

            modelBuilder.Entity<StagesTypeStages>(entity =>
            {
                entity.HasKey(e => new { e.IdStages, e.IdTypeStages })
                    .HasName("StagesTypeStages_PK");

                entity.HasOne(d => d.IdStagesNavigation)
                    .WithMany(p => p.StagesTypeStages)
                    .HasForeignKey(d => d.IdStages)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StagesTypeStages_Stages_FK");

                entity.HasOne(d => d.IdTypeStagesNavigation)
                    .WithMany(p => p.StagesTypeStages)
                    .HasForeignKey(d => d.IdTypeStages)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StagesTypeStages_TypeStages_FK");
            });

            modelBuilder.Entity<TypeFollow>(entity =>
            {
                entity.HasKey(e => e.IdTypeFollow)
                    .HasName("TypeComment_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Label).IsUnicode(false);
            });

            modelBuilder.Entity<TypeStages>(entity =>
            {
                entity.HasKey(e => e.IdStages)
                    .HasName("TypeStages_PK");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TypeStages1).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("User_PK");

                entity.Property(e => e.Password).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
