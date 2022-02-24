using LobsterAdventures.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL
{
    public class MyContext :DbContext
    {
        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<DecisionQuery> DecisionQueries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerDecisions> PlayerDecisions { get; set; }

        public MyContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Specify the relation between model classes. For now we have only one.
            //modelBuilder.Entity<Adventure>()
            //    .HasMany(a => a.DecisionQueries)
            //    .WithOne(b => b.Adventure)
            //    .HasForeignKey(b=>b.Id);
            //modelBuilder.Seed();
        }

    }
}
