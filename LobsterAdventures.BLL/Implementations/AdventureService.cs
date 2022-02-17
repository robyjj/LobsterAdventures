using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.BLL.Implementations
{
    public class AdventureService: IAdventureService
    {
        private readonly IAdventureRepository<Adventure> _adventureRepository;

        public AdventureService(IAdventureRepository<Adventure> adventureRepository)
        {
            _adventureRepository = adventureRepository;
        }

        public async Task AddDecision(int adventureId , AddDecisionModel model)
        {            
            await _adventureRepository.AddDecision(adventureId, model);
        }

        public async Task CreateAdventure(Adventure adventure)
        {
            adventure.DecisionQueries = new List<DecisionQuery>();
            var decisionQuery = new DecisionQuery
            {
                //Id = 1,
                Negative = null,
                Positive = null,
                ParentId = null,
                Title = "Are you ready to start your adventure ?"
            };
            adventure.DecisionQueries.Add(decisionQuery);
            await _adventureRepository.CreateAdventure(adventure);
        }

        public async Task<Adventure> GetAdventureById(int id)
        {
            return await _adventureRepository.GetAdventureById(id);
        }
        public async Task<IEnumerable<Adventure>> GetAdventures()
        {
            return await _adventureRepository.GetAdventures();
        }

        async Task<IEnumerable<DecisionQuery>> IAdventureService.GetQueriesByAdventureId(int adventureID)
        {
            return await _adventureRepository.GetQueriesByAdventureId(adventureID);
        }
    }
}
