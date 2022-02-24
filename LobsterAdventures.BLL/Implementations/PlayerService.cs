using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.DAL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using System;
using System.Collections.Generic;
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
        public async Task<PlayerPathModel> GetPlayerMappings(int playerId, int adventureId)
        {
            var player = await _playerRepository.GetPlayerMappings(playerId, adventureId);
            PlayerPathModel model = ConvertToPlayerPath(player);
            return model;
        }

        public Task MapDecisionToPlayer(int playerId, PlayerDecisionModel model)
        {
            return _playerRepository.MapDecisionToPlayer(playerId, model);
        }


        private PlayerPathModel ConvertToPlayerPath(Player player)
        {
            
            var playerDecisions = player.PlayerDecisions;
            //Conversion Logic
            var questions = new List<QuestionsModel>();
            playerDecisions.ForEach(decision => {
                var question = new QuestionsModel
                {
                    Question = decision.DecisionQueries.Title,
                    Answer = decision.IsPositive
                };
                questions.Add(question);
            });
            var playerPath = new PlayerPathModel
            {
                PlayerId = player.PlayerId,
                AdventureId = player.AdventureId,
                Questions = questions,

        };
            playerPath.Questions = questions;

            return playerPath;
        }
    }
}
