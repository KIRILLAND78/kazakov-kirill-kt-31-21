﻿using kazakov_kirill_kt_31_21.Data.Configurations;
using kazakov_kirill_kt_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace kazakov_kirill_kt_31_21.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
            modelBuilder.ApplyConfiguration(new RankConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        DbSet<Faculty> Faculties { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<Professor> Professors { get; set; }
        DbSet<Rank> Ranks { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Workload> Workloads { get; set; }
    }
}
