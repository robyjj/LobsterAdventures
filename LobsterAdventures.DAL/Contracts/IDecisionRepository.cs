using LobsterAdventures.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL.Contracts
{
    public interface IDecisionRepository<T>
    {
        //Task<IEnumerable<T>> GetDecisions();
        Task<T> GetNextDecision(NextDecisionModel nextDecisionModel);
        Task<T> GetDecisionByDecisionId(int decisionId);

        //Task<IEnumerable<DecisionQuery>> GetQueriesByAdventureId(int adventureID);
    }
}
