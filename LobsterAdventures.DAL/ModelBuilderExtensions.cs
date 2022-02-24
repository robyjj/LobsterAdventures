using LobsterAdventures.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL
{
    internal static class ModelBuilderExtensions
    {
       
        public static void Seed(this ModelBuilder modelBuilder)
        {            
            var adventure1 = new Adventure
            {
                AdventureId = 1,
                Name = "Adventure - 1",
                //DecisionQueries = dqList
            };           
            var player1 = new Player
            {
                PlayerId = 1
            };

            modelBuilder.Entity<Adventure>().HasData(adventure1);
            modelBuilder.Entity<Player>().HasData(player1);
        }
    }
}
