using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL.Contracts
{
    public interface IPlayerRepository<T>
    {
        Task MapDecisionToPlayer(int playerId, PlayerDecisionModel nextDecisionModel);
        Task<Player> GetPlayerMappings(int playerId, int adventureId);
    }
}
