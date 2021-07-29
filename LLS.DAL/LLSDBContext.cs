using LLS.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LLS.DAL
{
    public class LLSDBContext : DbContext
    {
        public LLSDBContext(DbContextOptions<LLSDBContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
               .HasIndex(b => b.title)
               .IsUnique();
        }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Experiment> Experiment { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<CourseExperiments> CourseExperiments { get; set; }
        public virtual DbSet<CourseUsers> CourseUsers { get; set; }
        public virtual DbSet<RolePermissions> RolePermissions { get; set; }
    }
}

