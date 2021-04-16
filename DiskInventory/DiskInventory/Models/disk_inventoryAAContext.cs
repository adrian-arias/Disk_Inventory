using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DiskInventory.Models
{
    public partial class disk_inventoryAAContext : DbContext
    {
        public disk_inventoryAAContext()
        {
        }

        public disk_inventoryAAContext(DbContextOptions<disk_inventoryAAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistType> ArtistTypes { get; set; }
        public virtual DbSet<Borrower> Borrowers { get; set; }
        public virtual DbSet<Disc> Discs { get; set; }
        public virtual DbSet<DiscHasArtist> DiscHasArtists { get; set; }
        public virtual DbSet<DiscHasBorrower> DiscHasBorrowers { get; set; }
        public virtual DbSet<DiscType> DiscTypes { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<ViewIndividualArtist> ViewIndividualArtists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\SQLDEV01;Database=disk_inventoryAA;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artist");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(60)
                    .HasColumnName("lname");

                entity.HasOne(d => d.ArtistType)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.ArtistTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__artist__artist_t__31EC6D26");
            });

            modelBuilder.Entity<ArtistType>(entity =>
            {
                entity.ToTable("artist_type");

                entity.Property(e => e.ArtistTypeId).HasColumnName("artist_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Borrower>(entity =>
            {
                entity.ToTable("borrower");

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("lname");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone_num");
            });

            modelBuilder.Entity<Disc>(entity =>
            {
                entity.ToTable("disc");

                entity.Property(e => e.DiscId).HasColumnName("disc_id");

                entity.Property(e => e.DiscName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("disc_name");

                entity.Property(e => e.DiscTypeId).HasColumnName("disc_type_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.DiscType)
                    .WithMany(p => p.Discs)
                    .HasForeignKey(d => d.DiscTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc__disc_type___2F10007B");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Discs)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc__genre_id__2D27B809");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Discs)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc__status_id__2E1BDC42");
            });

            modelBuilder.Entity<DiscHasArtist>(entity =>
            {
                entity.ToTable("disc_has_artist");

                entity.HasIndex(e => new { e.DiscId, e.ArtistId }, "UQ__disc_has__0C09421253019AE9")
                    .IsUnique();

                entity.Property(e => e.DiscHasArtistId).HasColumnName("disc_has_artist_id");

                entity.Property(e => e.ArtistId).HasColumnName("artist_id");

                entity.Property(e => e.DiscId).HasColumnName("disc_id");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.DiscHasArtists)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc_has___artis__3B75D760");

                entity.HasOne(d => d.Disc)
                    .WithMany(p => p.DiscHasArtists)
                    .HasForeignKey(d => d.DiscId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc_has___disc___3A81B327");
            });

            modelBuilder.Entity<DiscHasBorrower>(entity =>
            {
                entity.ToTable("disc_has_borrower");

                entity.Property(e => e.DiscHasBorrowerId).HasColumnName("disc_has_borrower_id");

                entity.Property(e => e.BorrowedDate).HasColumnName("borrowed_date");

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.DiscId).HasColumnName("disc_id");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasDefaultValueSql("(getdate()+(30))");

                entity.Property(e => e.ReturnedDate).HasColumnName("returned_date");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.DiscHasBorrowers)
                    .HasForeignKey(d => d.BorrowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc_has___borro__35BCFE0A");

                entity.HasOne(d => d.Disc)
                    .WithMany(p => p.DiscHasBorrowers)
                    .HasForeignKey(d => d.DiscId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disc_has___disc___36B12243");
            });

            modelBuilder.Entity<DiscType>(entity =>
            {
                entity.ToTable("disc_type");

                entity.Property(e => e.DiscTypeId).HasColumnName("disc_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<ViewIndividualArtist>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Individual_Artist");

                entity.Property(e => e.ArtistId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("artist_id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(60)
                    .HasColumnName("lname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
