using System;
using System.Collections.Generic;
using System.Text;
using CVManagement.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CVManagement.EntityFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CandidateLanguage>()
            .HasKey(cd => new { cd.CandidateId, cd.LanguageId });
            modelBuilder.Entity<CandidateLanguage>()
                .HasOne(cd => cd.Candidate)
                .WithMany(c => c.CandidateLanguages)
                .HasForeignKey(cd => cd.CandidateId);
            modelBuilder.Entity<CandidateLanguage>()
                .HasOne(cd => cd.Language)
                .WithMany(l => l.CandidateLanguages)
                .HasForeignKey(cd => cd.LanguageId);

            modelBuilder.Entity<CandidateFramework>()
            .HasKey(cf => new { cf.CandidateId, cf.FrameworkId });
            modelBuilder.Entity<CandidateFramework>()
                .HasOne(cf => cf.Candidate)
                .WithMany(c => c.CandidateFrameworks)
                .HasForeignKey(cf => cf.CandidateId);
            modelBuilder.Entity<CandidateFramework>()
                .HasOne(cf => cf.Framework)
                .WithMany(f => f.CandidateFrameworks)
                .HasForeignKey(cf => cf.FrameworkId);

            modelBuilder.Entity<LanguageFramework>()
                .HasKey(lf => new { lf.LanguageId, lf.FrameworkId });
            modelBuilder.Entity<LanguageFramework>()
                .HasOne(lf => lf.Language)
                .WithMany(l => l.LanguageFrameworks)
                .HasForeignKey(lf => lf.LanguageId);
            modelBuilder.Entity<LanguageFramework>()
                .HasOne(lf => lf.Framework)
                .WithMany(f => f.LanguageFrameworks)
                .HasForeignKey(lf => lf.FrameworkId);

        }
    }
}
