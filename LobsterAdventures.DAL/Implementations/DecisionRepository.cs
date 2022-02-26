using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LobsterAdventures.DAL.Implementations
{
    public class DecisionRepository : IDecisionRepository<DecisionQuery>
    {

        private readonly MyContext _context;
        public DecisionRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<DecisionQuery> GetNextDecision(NextDecisionModel nextDecisionModel)
        {
            var currentDecisionDetails = await GetDecisionByDecisionId(nextDecisionModel.DecisionId);
            if(nextDecisionModel.IsPositive && currentDecisionDetails?.PositiveId != null)
            {
                var nextDecision =await GetDecisionByDecisionId(currentDecisionDetails.PositiveId.GetValueOrDefault());
                return nextDecision;
            }
            else if(currentDecisionDetails?.NegativeId != null)
            {
                var nextDecision = await GetDecisionByDecisionId(currentDecisionDetails.NegativeId.GetValueOrDefault());
                return nextDecision;
            }

            return new DecisionQuery() { Title = "End of Game" };
        }

        public async Task<DecisionQuery> GetDecisionByDecisionId(int decisionId)
        {
            return await _context.DecisionQueries.Include("Adventure").Where(d=>d.Id == decisionId).SingleOrDefaultAsync();
                            
        }

        public async Task<IEnumerable<DecisionQuery>> GetQueriesByAdventureId(int adventureID)
        {
            return await _context.DecisionQueries
                .Where(d => d.AdventureId == adventureID).ToArrayAsync();
            //.Include("Adventure")

        }
    }
}
