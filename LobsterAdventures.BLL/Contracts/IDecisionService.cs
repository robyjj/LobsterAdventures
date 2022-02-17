using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using System.Threading.Tasks;

namespace LobsterAdventures.BLL.Contracts
{
    public interface IDecisionService<T>
    {
        Task<T> GetNextDecision(NextDecisionModel nextDecisionModel);
    }
}
