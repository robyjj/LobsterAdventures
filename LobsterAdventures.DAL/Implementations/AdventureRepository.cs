using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL.Implementations
{
    public class AdventureRepository : IAdventureRepository<Adventure>
    {
        private readonly MyContext _context;
        public AdventureRepository(MyContext context)
        {
            _context = context;
        }

        public async Task AddDecision(int adventureId, AddDecisionModel model)
        {
            var adventuresList = _context.Adventures.Include("DecisionQueries").ToArrayAsync();
            var currentDecisionQuery = model.DecisionQuery;
            var adventure = await GetAdventureById(adventureId);
            if (adventure.DecisionQueries == null)
                adventure.DecisionQueries = new List<DecisionQuery>();
            currentDecisionQuery.Adventure = adventure;
            currentDecisionQuery.AdventureId = adventure.AdventureId;
            _context.DecisionQueries.Add(currentDecisionQuery);

            //Fetch parent decision for the current decision
            var parentId = model?.DecisionQuery?.ParentId;
            var parentDecisionQuery = await _context.DecisionQueries.FindAsync(parentId);
            if (model.IsPositive)
            {
                parentDecisionQuery.Positive = currentDecisionQuery;
            }
            else
            {
                parentDecisionQuery.Negative = currentDecisionQuery;
            }
            
            //decisionQuery.Adventure = adventure;
            //adventure.DecisionQueries.Add(decisionQuery);
            //_adventureContext.DecisionQueries.Add(decisionQuery);
            //_adventureContext.Entry(adventure).State = EntityState.Added;
            //_adventureContext.Adventures.Update(adventure);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAdventure(Adventure adventure)
        {
            _context.Adventures.Add(adventure);
            await _context.SaveChangesAsync();
        }

        public Task<Adventure> DeleteAdventure(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Adventure>> DeleteMultiple(int[] ids)
        {
            throw new NotImplementedException();
        }

        public async Task<Adventure> GetAdventureById(int id)
        {
            return await _context.Adventures.FindAsync(id);
        }

        public async Task<IEnumerable<Adventure>> GetAdventures()
        {
            return await _context.Adventures.Include("DecisionQueries").ToArrayAsync();
        }

        public async Task UpdateAdventure(int AdventureID, Adventure adventure)
        {
            //var adventure = await GetAdventureById(adventureId);
            //adventure.DecisionQueries.Add(decisionQuery);
            _context.Adventures.Update(adventure);
            await _context.SaveChangesAsync();
        }
    }
}
