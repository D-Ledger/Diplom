using Microsoft.EntityFrameworkCore;
using RZD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZD
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Floor> Floors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<RailwayEngineerInspection> RailwayEngineerInspections { get; set; }
        public virtual DbSet<TypesPath> TypesPaths { get; set; }
        public DbSet<Way> Ways { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<InspectionsAuditorTrain> InspectionsAuditorTrains { get; set; }
        public DbSet<InspectionsAuditorWay> InspectionsAuditorWays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=root;DataBase=rzd");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=probnik;Username=postgres;Password=root");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InspectionsAuditorTrain>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("InspectionsAuditorTrains_pkey");

                entity.Property(e => e.ArrivalStation).HasMaxLength(100);
                entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
                entity.Property(e => e.DepartureStation).HasMaxLength(100);

                entity.HasOne(d => d.AuditorNavigation).WithMany(p => p.InspectionsAuditorTrains)
                    .HasForeignKey(d => d.Auditor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InspectionsAuditorTrains_Auditor_fkey");
            });

            modelBuilder.Entity<InspectionsAuditorWay>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("InspectionsAuditorWays_pkey");

                entity.Property(e => e.Date).HasColumnType("timestamp without time zone");
                entity.Property(e => e.Description).HasMaxLength(100);
                entity.Property(e => e.Nways).HasColumnName("NWays");

                entity.HasOne(d => d.AuditorNavigation).WithMany(p => p.InspectionsAuditorWays)
                    .HasForeignKey(d => d.Auditor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("InspectionsAuditorWays_Auditor_fkey");

                entity.HasOne(d => d.NwaysNavigation).WithMany(p => p.InspectionsAuditorWays)
                    .HasForeignKey(d => d.Nways)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_inspectionsauditorways");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Positions_pkey");

                entity.Property(e => e.PositionName).HasMaxLength(100);
            });

            modelBuilder.Entity<RailwayEngineerInspection>(entity =>
            {
                entity.HasKey(e => e.RailwayEngineerInspectionId).HasName("RailwayEngineerInspections_pkey");

                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.InspectionDate).HasColumnType("timestamp without time zone");
                entity.Property(e => e.Vways).HasColumnName("VWays");

                entity.HasOne(d => d.RailwayEngineer).WithMany(p => p.RailwayEngineerInspections)
                    .HasForeignKey(d => d.RailwayEngineerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RailwayEngineerInspections_RailwayEngineerId_fkey");

                entity.HasOne(d => d.VwaysNavigation).WithMany(p => p.RailwayEngineerInspections)
                    .HasForeignKey(d => d.Vways)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_railwayengineerinspections");
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.TrainId).HasName("Trains_pkey");

                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.EndOfInspection).HasColumnType("timestamp without time zone");
                entity.Property(e => e.StartOfInspection).HasColumnType("timestamp without time zone");

                entity.HasOne(d => d.UserNavigation).WithMany(p => p.Trains)
                    .HasForeignKey(d => d.WagonInspectorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Trains_WagonInspectorId_fkey");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Floors_pkey");

                entity.Property(e => e.Gender).HasMaxLength(10);

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Users_pkey");

                entity.Property(e => e.Fullname).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.PositionNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_PositionId_fkey");

                entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Users)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_Gender_fkey");
            });

            modelBuilder.Entity<TypesPath>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("TypesPaths_pkey");

                entity.Property(e => e.ViewWays).HasMaxLength(100);
            });

            modelBuilder.Entity<Way>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("Ways_pkey");

                entity.Property(e => e.ViewWays).HasMaxLength(100);
                entity.Property(e => e.WaysName).HasMaxLength(100);

                entity.HasOne(d => d.ViewWaysNavigation).WithMany(p => p.Ways)
                                    .HasForeignKey(d => d.ViewWays)
                                    .OnDelete(DeleteBehavior.ClientSetNull)
                                    .HasConstraintName("Ways_ViewWays_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}