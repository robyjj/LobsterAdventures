using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using System.Threading.Tasks;

namespace LobsterAdventures.BLL.Implementations
{
    public class DecisionService : IDecisionService<DecisionQuery>
    {
        private readonly IDecisionRepository<DecisionQuery> _decisionRepository;

        public DecisionService(IDecisionRepository<DecisionQuery> decisionRepository)
        {
            _decisionRepository = decisionRepository;
        }
        public async Task<DecisionQuery> GetNextDecision(NextDecisionModel nextDecisionModel)
        {
            return await _decisionRepository.GetNextDecision(nextDecisionModel);
        }
    }
}
