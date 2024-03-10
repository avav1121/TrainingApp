using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;



namespace TrainingApp
{
    internal class ApplicationContext : DbContext 
    {
        private string _databasePath;
        public DbSet<TrainingResult> Friends { get; set; }
        public ApplicationContext(string databasePath)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
