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
            var dqList =new List<DecisionQuery>();
            var adventure1 = new Adventure
            {
                AdventureId = 1,
                Name = "Adventure - 1",
                DecisionQueries = dqList
            };
            var dq3 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 3,
                Negative = null,
                Positive = null,
                ParentId = 1,
                Title = "Bye Bye ?"
            };
            dqList.Add(dq3);
            var dq2 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 2,
                Negative = null,
                Positive = null,
                ParentId = 1,
                Title = "Do you want to go Left ?"
            };
            dqList.Add(dq2);
            var dq1 = new DecisionQuery
            {
                AdventureId = 1,
                Adventure = adventure1,
                Id = 1,
                NegativeId = 3,
                PositiveId = 2,
                ParentId = null,
                Title = "Are you ready to start your adventure ?"
            };
            dqList.Add(dq1);

            
            modelBuilder.Entity<Adventure>().HasData(adventure1);
        }
    }
}
