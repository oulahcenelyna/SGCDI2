using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SGCDI.model
{
    public partial class sgcdiContext : DbContext
    {
        public sgcdiContext()
        {
        }

        public sgcdiContext(DbContextOptions<sgcdiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<ClassesElefe> ClassesEleves { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<DisciplinesClass> DisciplinesClasses { get; set; }
        public virtual DbSet<DisciplinesOuvrage> DisciplinesOuvrages { get; set; }
        public virtual DbSet<Documentaliste> Documentalistes { get; set; }
        public virtual DbSet<Elefe> Eleves { get; set; }
        public virtual DbSet<Emprunteur> Emprunteurs { get; set; }
        public virtual DbSet<EmprunteursExemplaire> EmprunteursExemplaires { get; set; }
        public virtual DbSet<Exemplaire> Exemplaires { get; set; }
        public virtual DbSet<Ouvrage> Ouvrages { get; set; }
        public virtual DbSet<Professeur> Professeurs { get; set; }
        public virtual DbSet<ProfesseursDiscipline> ProfesseursDisciplines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=sgcdi");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PRIMARY");

                entity.ToTable("classes");

                entity.Property(e => e.IdClasse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idClasse");

                entity.Property(e => e.CategorieClasse)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("categorieClasse");
            });

            modelBuilder.Entity<ClassesElefe>(entity =>
            {
                entity.HasKey(e => new { e.IdEleve, e.IdClasse })
                    .HasName("PRIMARY");

                entity.ToTable("classes_eleves");

                entity.HasIndex(e => e.IdClasse, "idClasse");

                entity.Property(e => e.IdEleve)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEleve");

                entity.Property(e => e.IdClasse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idClasse");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ClassesEleves)
                    .HasForeignKey(d => d.IdClasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classes_eleves_ibfk_1");

                entity.HasOne(d => d.IdEleveNavigation)
                    .WithMany(p => p.ClassesEleves)
                    .HasForeignKey(d => d.IdEleve)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("classes_eleves_ibfk_2");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => e.IdDiscipline)
                    .HasName("PRIMARY");

                entity.ToTable("disciplines");

                entity.HasIndex(e => e.IdDocumentaliste, "idDocumentaliste");

                entity.Property(e => e.IdDiscipline)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDiscipline");

                entity.Property(e => e.IdDocumentaliste)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocumentaliste");

                entity.Property(e => e.ImageCat)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("imageCat");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("libelle");

                entity.HasOne(d => d.IdDocumentalisteNavigation)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.IdDocumentaliste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disciplines_ibfk_1");
            });

            modelBuilder.Entity<DisciplinesClass>(entity =>
            {
                entity.HasKey(e => new { e.IdDiscipline, e.IdClasse })
                    .HasName("PRIMARY");

                entity.ToTable("disciplines_classes");

                entity.HasIndex(e => e.IdClasse, "idClasse");

                entity.Property(e => e.IdDiscipline)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDiscipline");

                entity.Property(e => e.IdClasse)
                    .HasColumnType("int(11)")
                    .HasColumnName("idClasse");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.DisciplinesClasses)
                    .HasForeignKey(d => d.IdClasse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disciplines_classes_ibfk_1");

                entity.HasOne(d => d.IdDisciplineNavigation)
                    .WithMany(p => p.DisciplinesClasses)
                    .HasForeignKey(d => d.IdDiscipline)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disciplines_classes_ibfk_2");
            });

            modelBuilder.Entity<DisciplinesOuvrage>(entity =>
            {
                entity.HasKey(e => new { e.IdDiscipline, e.IdOuvrage })
                    .HasName("PRIMARY");

                entity.ToTable("disciplines_ouvrages");

                entity.HasIndex(e => e.IdOuvrage, "idOuvrage");

                entity.Property(e => e.IdDiscipline)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDiscipline");

                entity.Property(e => e.IdOuvrage)
                    .HasColumnType("int(11)")
                    .HasColumnName("idOuvrage");

                entity.HasOne(d => d.IdDisciplineNavigation)
                    .WithMany(p => p.DisciplinesOuvrages)
                    .HasForeignKey(d => d.IdDiscipline)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disciplines_ouvrages_ibfk_1");

                entity.HasOne(d => d.IdOuvrageNavigation)
                    .WithMany(p => p.DisciplinesOuvrages)
                    .HasForeignKey(d => d.IdOuvrage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disciplines_ouvrages_ibfk_2");
            });

            modelBuilder.Entity<Documentaliste>(entity =>
            {
                entity.HasKey(e => e.IdDocumentaliste)
                    .HasName("PRIMARY");

                entity.ToTable("documentalistes");

                entity.Property(e => e.IdDocumentaliste)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocumentaliste");

                entity.Property(e => e.AdresseMail)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("adresseMail");

                entity.Property(e => e.MotDePasse)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("motDePasse");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prenom");
            });

            modelBuilder.Entity<Elefe>(entity =>
            {
                entity.HasKey(e => e.IdEmprunteur)
                    .HasName("PRIMARY");

                entity.ToTable("eleves");

                entity.HasIndex(e => e.IdEmprunteur, "idEmprunteur")
                    .IsUnique();

                entity.Property(e => e.IdEmprunteur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmprunteur");

                entity.Property(e => e.IdEleve)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEleve");

                entity.HasOne(d => d.IdEmprunteurNavigation)
                    .WithOne(p => p.Elefe)
                    .HasForeignKey<Elefe>(d => d.IdEmprunteur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eleves_ibfk_1");
            });

            modelBuilder.Entity<Emprunteur>(entity =>
            {
                entity.HasKey(e => e.IdEmprunteur)
                    .HasName("PRIMARY");

                entity.ToTable("emprunteurs");

                entity.Property(e => e.IdEmprunteur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmprunteur");

                entity.Property(e => e.AdresseMail)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("adresseMail");

                entity.Property(e => e.MotDePasse)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("nom");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("prenom");
            });

            modelBuilder.Entity<EmprunteursExemplaire>(entity =>
            {
                entity.HasKey(e => new { e.IdExemplaire, e.IdEmprunteur })
                    .HasName("PRIMARY");

                entity.ToTable("emprunteurs_exemplaires");

                entity.HasIndex(e => e.IdEmprunteur, "idEmprunteur");

                entity.HasIndex(e => e.IdExemplaire, "idExemplaire")
                    .IsUnique();

                entity.Property(e => e.IdExemplaire)
                    .HasColumnType("int(11)")
                    .HasColumnName("idExemplaire");

                entity.Property(e => e.IdEmprunteur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmprunteur");

                entity.Property(e => e.DebutEmprunt)
                    .HasColumnType("date")
                    .HasColumnName("debutEmprunt");

                entity.Property(e => e.FinEmprunt)
                    .HasColumnType("date")
                    .HasColumnName("finEmprunt");

                entity.HasOne(d => d.IdEmprunteurNavigation)
                    .WithMany(p => p.EmprunteursExemplaires)
                    .HasForeignKey(d => d.IdEmprunteur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emprunteurs_exemplaires_ibfk_1");

                entity.HasOne(d => d.IdExemplaireNavigation)
                    .WithOne(p => p.EmprunteursExemplaire)
                    .HasForeignKey<EmprunteursExemplaire>(d => d.IdExemplaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("emprunteurs_exemplaires_ibfk_2");
            });

            modelBuilder.Entity<Exemplaire>(entity =>
            {
                entity.HasKey(e => e.IdExemplaire)
                    .HasName("PRIMARY");

                entity.ToTable("exemplaires");

                entity.HasIndex(e => e.IdDocumentaliste, "idDocumentaliste");

                entity.HasIndex(e => e.IdOuvrage, "idOuvrage");

                entity.Property(e => e.IdExemplaire)
                    .HasColumnType("int(11)")
                    .HasColumnName("idExemplaire");

                entity.Property(e => e.CodeBarreExemplaire)
                    .HasColumnType("int(11)")
                    .HasColumnName("codeBarreExemplaire");

                entity.Property(e => e.IdDocumentaliste)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocumentaliste");

                entity.Property(e => e.IdOuvrage)
                    .HasColumnType("int(11)")
                    .HasColumnName("idOuvrage");

                entity.Property(e => e.Reserve)
                    .HasColumnName("reserve")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.IdDocumentalisteNavigation)
                    .WithMany(p => p.Exemplaires)
                    .HasForeignKey(d => d.IdDocumentaliste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exemplaires_ibfk_1");

                entity.HasOne(d => d.IdOuvrageNavigation)
                    .WithMany(p => p.Exemplaires)
                    .HasForeignKey(d => d.IdOuvrage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("exemplaires_ibfk_2");
            });

            modelBuilder.Entity<Ouvrage>(entity =>
            {
                entity.HasKey(e => e.IdOuvrage)
                    .HasName("PRIMARY");

                entity.ToTable("ouvrages");

                entity.HasIndex(e => e.IdDocumentaliste, "idDocumentaliste");

                entity.Property(e => e.IdOuvrage)
                    .HasColumnType("int(11)")
                    .HasColumnName("idOuvrage");

                entity.Property(e => e.Auteur)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("auteur");

                entity.Property(e => e.IdDocumentaliste)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDocumentaliste");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("image");

                entity.Property(e => e.Resume)
                    .IsRequired()
                    .HasColumnType("mediumtext")
                    .HasColumnName("resume");

                entity.Property(e => e.Titre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("titre");

                entity.HasOne(d => d.IdDocumentalisteNavigation)
                    .WithMany(p => p.Ouvrages)
                    .HasForeignKey(d => d.IdDocumentaliste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ouvrages_ibfk_1");
            });

            modelBuilder.Entity<Professeur>(entity =>
            {
                entity.HasKey(e => e.IdEmprunteur)
                    .HasName("PRIMARY");

                entity.ToTable("professeurs");

                entity.HasIndex(e => e.IdEmprunteur, "idEmprunteur")
                    .IsUnique();

                entity.Property(e => e.IdEmprunteur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmprunteur");

                entity.Property(e => e.IdProfesseur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProfesseur");

                entity.HasOne(d => d.IdEmprunteurNavigation)
                    .WithOne(p => p.Professeur)
                    .HasForeignKey<Professeur>(d => d.IdEmprunteur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("professeurs_ibfk_1");
            });

            modelBuilder.Entity<ProfesseursDiscipline>(entity =>
            {
                entity.HasKey(e => new { e.IdDiscipline, e.IdProfesseur })
                    .HasName("PRIMARY");

                entity.ToTable("professeurs_disciplines");

                entity.HasIndex(e => e.IdProfesseur, "idProfesseur");

                entity.Property(e => e.IdDiscipline)
                    .HasColumnType("int(11)")
                    .HasColumnName("idDiscipline");

                entity.Property(e => e.IdProfesseur)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProfesseur");

                entity.HasOne(d => d.IdDisciplineNavigation)
                    .WithMany(p => p.ProfesseursDisciplines)
                    .HasForeignKey(d => d.IdDiscipline)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("professeurs_disciplines_ibfk_1");

                entity.HasOne(d => d.IdProfesseurNavigation)
                    .WithMany(p => p.ProfesseursDisciplines)
                    .HasForeignKey(d => d.IdProfesseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("professeurs_disciplines_ibfk_2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
