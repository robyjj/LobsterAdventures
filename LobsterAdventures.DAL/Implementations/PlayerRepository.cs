using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL.Implementations
{
    public class PlayerRepository : IPlayerRepository<Player>
    {
        private readonly MyContext _context;
        public PlayerRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<Player> GetPlayerMappings(int playerId, int adventureId)
        {
            var player = await _context.Players
                .Include(p=>p.PlayerDecisions)
                .ThenInclude(c=>c.DecisionQueries)
                //.Include("PlayerDecisions")
                //.Include("DecisionQueries")
                .Where(p => p.PlayerId == playerId)
                .SingleOrDefaultAsync();
            //var playerMappings =  await _context.PlayerDecisions
            //    .Include("DecisionQueries")
            //    .Where(d => d.PlayerId == playerId
            //    && d.AdventureId == adventureId).ToListAsync();
            return player;


        }
        public async Task MapDecisionToPlayer(int playerId, PlayerDecisionModel model)
        {
            //Get Player Details
            var playerDetails = _context.Players
                .Where(p => p.PlayerId == model.PlayerId).FirstOrDefault();


            //Get Player Decision Details
            var playerDecisionDetails = _context.PlayerDecisions.Include("DecisionQueries")
                .Where(p=>p.PlayerId == model.PlayerId).FirstOrDefault();
            
            var queryDecision = await _context.DecisionQueries
                .Where(d => d.Id == model.DecisionQueryId)
                .SingleOrDefaultAsync();

            var playerDecision = new PlayerDecisions
            {
                DecisionId = model.DecisionQueryId,
                DecisionQueries = queryDecision,
                IsPositive = model.IsPositive,
                AdventureId = model.AdventureId,
                PlayerId = model.PlayerId
            };
            playerDetails.PlayerDecisions = playerDetails.PlayerDecisions == null ?
                           new List<PlayerDecisions>(): playerDetails.PlayerDecisions;
            playerDetails.PlayerDecisions?.Add(playerDecision);
            _context.PlayerDecisions.Add(playerDecision);
            //_context.Players.Add(playerDetails);
            await _context.SaveChangesAsync();
        }
    }
}
