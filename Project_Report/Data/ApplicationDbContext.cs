using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Project_Report.Models;


namespace Project_Report.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                        .HasOne(q => q.Question)
                        .WithMany(q => q.Answers)
                        .IsRequired()
                        .HasForeignKey(x => x.QuestionId)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Answer>()
                        .HasOne(r => r.Report)
                        .WithMany(r => r.Answers)
                        .HasForeignKey(x => x.ReportId)
                        .OnDelete(DeleteBehavior.NoAction);
                     

            base.OnModelCreating(modelBuilder);
        }

    }
}
