using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LobsterAdventures.BLL.Contracts
{
    public interface IDecisionService<T>
    {
        Task<T> GetNextDecision(NextDecisionModel nextDecisionModel);
        Task<IEnumerable<T>> GetQueriesByAdventureId(int adventureID);
    }
}
