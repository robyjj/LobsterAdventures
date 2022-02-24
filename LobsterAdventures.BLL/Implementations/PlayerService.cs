using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using System.Threading.Tasks;

namespace LobsterAdventures.BLL.Implementations
{
    public class PlayerService : IPlayerService<Player>
    {
        private readonly IPlayerRepository<Player> _playerRepository;

        public PlayerService(IPlayerRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }
        public async Task<Player> GetPlayerMappings(int playerId, int adventureId)
        {
            var player = await _playerRepository.GetPlayerMappings(playerId, adventureId);
            return player;
        }
        public Task MapDecisionToPlayer(int playerId, PlayerDecisionModel model)
        {
            return _playerRepository.MapDecisionToPlayer(playerId, model);
        }
    }
}
