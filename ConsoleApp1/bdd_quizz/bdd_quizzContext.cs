﻿using Microsoft.EntityFrameworkCore;

namespace Quizz_Models.bdd_quizz
{
    public partial class bdd_quizzContext : DbContext
    {
        public bdd_quizzContext()
        {
        }

        public bdd_quizzContext(DbContextOptions<bdd_quizzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<CompteQuizz> CompteQuizz { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Personnage> Personnage { get; set; }
        public virtual DbSet<PropositionReponse> PropositionReponse { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quizz> Quizz { get; set; }
        public virtual DbSet<QuizzQuestion> QuizzQuestion { get; set; }
        public virtual DbSet<ReponseCandidat> ReponseCandidat { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<TauxComplexite> TauxComplexite { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=bdd_quizz");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasKey(e => e.PkCompte)
                    .HasName("PRIMARY");

                entity.ToTable("Compte");

                entity.HasIndex(e => e.FkPermission)
                    .HasName("fk_Compte_Permission1_idx");

                entity.HasIndex(e => e.Mail)
                    .HasName("mail_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PkCompte).HasColumnName("pk_Compte");

                entity.Property(e => e.FkPermission).HasColumnName("fk_Permission");

                entity.Property(e => e.Mail)
                    .HasColumnName("mail")
                    .HasMaxLength(45);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(45);

                entity.Property(e => e.Prenom)
                    .HasColumnName("prenom")
                    .HasMaxLength(45);

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.FkPermissionNavigation)
                    .WithMany(p => p.Compte)
                    .HasForeignKey(d => d.FkPermission)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Compte_Permission1");
            });

            modelBuilder.Entity<CompteQuizz>(entity =>
            {
                entity.HasKey(e => new { e.FkCompte, e.FkQuizz })
                    .HasName("PRIMARY");

                entity.ToTable("Compte_quizz");

                entity.HasIndex(e => e.FkCompte)
                    .HasName("fk_Compte_has_quizz_Compte1_idx");

                entity.HasIndex(e => e.FkQuizz)
                    .HasName("fk_Compte_has_quizz_quizz1_idx");

                entity.Property(e => e.FkCompte).HasColumnName("fk_Compte");

                entity.Property(e => e.FkQuizz).HasColumnName("fk_quizz");

                entity.HasOne(d => d.FkCompteNavigation)
                    .WithMany(p => p.CompteQuizz)
                    .HasForeignKey(d => d.FkCompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Compte_has_quizz_Compte1");

                entity.HasOne(d => d.FkQuizzNavigation)
                    .WithMany(p => p.CompteQuizz)
                    .HasForeignKey(d => d.FkQuizz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Compte_has_quizz_quizz1");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PkPermission)
                    .HasName("PRIMARY");

                entity.ToTable("Permission");

                entity.Property(e => e.PkPermission).HasColumnName("pk_Permission");

                entity.Property(e => e.AjouterQuest).HasColumnName("ajouter_quest");

                entity.Property(e => e.GenererQuizz).HasColumnName("generer_quizz");

                entity.Property(e => e.ModifierQuest).HasColumnName("modifier_quest");

                entity.Property(e => e.SupprQuestion).HasColumnName("suppr_question");
            });

            modelBuilder.Entity<Personnage>(entity =>
            {
                entity.HasKey(e => e.PkPersonnage)
                    .HasName("PRIMARY");

                entity.ToTable("personnage");

                entity.Property(e => e.PkPersonnage).HasColumnName("pk_personnage");

                entity.Property(e => e.Defense).HasColumnName("defense");

                entity.Property(e => e.Degat).HasColumnName("degat");

                entity.Property(e => e.IdGroupe).HasColumnName("id_groupe");

                entity.Property(e => e.NbRound).HasColumnName("nb_round");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(45);

                entity.Property(e => e.Vie).HasColumnName("vie");
            });

            modelBuilder.Entity<PropositionReponse>(entity =>
            {
                entity.HasKey(e => e.PkReponse)
                    .HasName("PRIMARY");

                entity.ToTable("proposition_reponse");

                entity.HasIndex(e => e.FkQuestion)
                    .HasName("fk_reponse_question1_idx");

                entity.Property(e => e.PkReponse).HasColumnName("pk_reponse");

                entity.Property(e => e.EstBonne).HasColumnName("est_bonne");

                entity.Property(e => e.FkQuestion).HasColumnName("fk_question");

                entity.Property(e => e.Texte)
                    .HasColumnName("texte")
                    .HasColumnType("longtext");

                entity.HasOne(d => d.FkQuestionNavigation)
                    .WithMany(p => p.PropositionReponse)
                    .HasForeignKey(d => d.FkQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reponse_question1");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.PkQuestion)
                    .HasName("PRIMARY");

                entity.ToTable("question");

                entity.HasIndex(e => e.FkComplexite)
                    .HasName("fk_question_taux complexite1_idx");

                entity.HasIndex(e => e.FkTheme)
                    .HasName("fk_question_theme1_idx");

                entity.Property(e => e.PkQuestion).HasColumnName("pk_question");

                entity.Property(e => e.ARepondu).HasColumnName("a_repondu");

                entity.Property(e => e.Enonce)
                    .HasColumnName("enonce")
                    .HasColumnType("longtext");

                entity.Property(e => e.FkComplexite).HasColumnName("fk_complexite");

                entity.Property(e => e.FkTheme).HasColumnName("fk_theme");

                entity.Property(e => e.NvComplexite)
                    .HasColumnName("nv_complexite")
                    .HasMaxLength(45);

                entity.HasOne(d => d.FkComplexiteNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.FkComplexite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question_taux complexite1");

                entity.HasOne(d => d.FkThemeNavigation)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.FkTheme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_question_theme1");
            });

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.HasKey(e => e.PkQuizz)
                    .HasName("PRIMARY");

                entity.ToTable("quizz");

                entity.HasComment("La table quizz est en fait un tableau de question. Elle met en lien une question (et donc ca réponse enregistrée) et l'utilisateur.");

                entity.HasIndex(e => e.FkComplexite)
                    .HasName("fk_quizz_taux complexite1_idx");

                entity.HasIndex(e => e.FkTheme)
                    .HasName("fk_quizz_theme1_idx");

                entity.Property(e => e.PkQuizz).HasColumnName("pk_quizz");

                entity.Property(e => e.Chrono).HasColumnName("chrono");

                entity.Property(e => e.FkComplexite).HasColumnName("fk_complexite");

                entity.Property(e => e.FkTheme).HasColumnName("fk_theme");

                entity.HasOne(d => d.FkComplexiteNavigation)
                    .WithMany(p => p.Quizz)
                    .HasForeignKey(d => d.FkComplexite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quizz_taux complexite1");

                entity.HasOne(d => d.FkThemeNavigation)
                    .WithMany(p => p.Quizz)
                    .HasForeignKey(d => d.FkTheme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quizz_theme1");
            });

            modelBuilder.Entity<QuizzQuestion>(entity =>
            {
                entity.HasKey(e => new { e.FkQuizz, e.FkQuestion })
                    .HasName("PRIMARY");

                entity.ToTable("quizz_question");

                entity.HasIndex(e => e.FkQuestion)
                    .HasName("fk_quizz_has_question_question1_idx");

                entity.HasIndex(e => e.FkQuizz)
                    .HasName("fk_quizz_has_question_quizz1_idx");

                entity.Property(e => e.FkQuizz).HasColumnName("fk_quizz");

                entity.Property(e => e.FkQuestion).HasColumnName("fk_question");

                entity.HasOne(d => d.FkQuestionNavigation)
                    .WithMany(p => p.QuizzQuestion)
                    .HasForeignKey(d => d.FkQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quizz_has_question_question1");

                entity.HasOne(d => d.FkQuizzNavigation)
                    .WithMany(p => p.QuizzQuestion)
                    .HasForeignKey(d => d.FkQuizz)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_quizz_has_question_quizz1");
            });

            modelBuilder.Entity<ReponseCandidat>(entity =>
            {
                entity.HasKey(e => e.PkReponse)
                    .HasName("PRIMARY");

                entity.ToTable("reponse_candidat");

                entity.HasIndex(e => e.FkCompte)
                    .HasName("fk_reponse_candidat_Compte1_idx");

                entity.HasIndex(e => e.FkQuestion)
                    .HasName("fk_reponse_candidat_question1_idx");

                entity.Property(e => e.PkReponse).HasColumnName("pk_reponse");

                entity.Property(e => e.Commentaire)
                    .HasColumnName("commentaire")
                    .HasMaxLength(45);

                entity.Property(e => e.FkCompte).HasColumnName("fk_Compte");

                entity.Property(e => e.FkQuestion).HasColumnName("fk_question");

                entity.Property(e => e.Reponse)
                    .HasColumnName("reponse")
                    .HasColumnType("longtext");

                entity.HasOne(d => d.FkCompteNavigation)
                    .WithMany(p => p.ReponseCandidat)
                    .HasForeignKey(d => d.FkCompte)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reponse_candidat_Compte1");

                entity.HasOne(d => d.FkQuestionNavigation)
                    .WithMany(p => p.ReponseCandidat)
                    .HasForeignKey(d => d.FkQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reponse_candidat_question1");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.PkSkill)
                    .HasName("PRIMARY");

                entity.ToTable("skill");

                entity.HasIndex(e => e.PersonnageIdpersonnage)
                    .HasName("fk_skill_personnage1_idx");

                entity.Property(e => e.PkSkill).HasColumnName("pk_skill");

                entity.Property(e => e.Degat).HasColumnName("degat");

                entity.Property(e => e.Frequence).HasColumnName("frequence");

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(45);

                entity.Property(e => e.PersonnageIdpersonnage).HasColumnName("personnage_idpersonnage");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.PersonnageIdpersonnageNavigation)
                    .WithMany(p => p.Skill)
                    .HasForeignKey(d => d.PersonnageIdpersonnage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_skill_personnage1");
            });

            modelBuilder.Entity<TauxComplexite>(entity =>
            {
                entity.HasKey(e => e.PkComplexite)
                    .HasName("PRIMARY");

                entity.ToTable("taux_complexite");

                entity.Property(e => e.PkComplexite).HasColumnName("pk_complexite");

                entity.Property(e => e.Niveau)
                    .HasColumnName("niveau")
                    .HasMaxLength(45);

                entity.Property(e => e.QuestConfirme).HasColumnName("quest_confirme");

                entity.Property(e => e.QuestionExperimente).HasColumnName("question_experimente");

                entity.Property(e => e.QuestionJunior).HasColumnName("question_junior");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.HasKey(e => e.PkTheme)
                    .HasName("PRIMARY");

                entity.ToTable("theme");

                entity.Property(e => e.PkTheme).HasColumnName("pk_theme");

                entity.Property(e => e.NomTheme)
                    .HasColumnName("nom_theme")
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
