using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LobsterAdventures.Controllers
{
    [ApiVersion("1.0")]
    [Route("Players")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService<Player> _playerService;

        public PlayerController(IPlayerService<Player> playerService)
        {
            _playerService = playerService;
        }

        /// <summary>
        /// Returns Player path for an adventure
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{playerId}/Adventure/{adventureId}")]
        public async Task<ActionResult<Player>> Get(int playerId, int adventureId)
        {
            var playerMappings = await _playerService.GetPlayerMappings(playerId, adventureId);
            if (playerMappings == null)
            {
                return NotFound();
            }
            return Ok(playerMappings);
        }

        /// <summary>
        /// Maps the decision taken to the associated player
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{playerId}/Decision")]
        public async Task<ActionResult<Player>> Post(int playerId, [FromBody] PlayerDecisionModel model)
        {
            var player = new Player();            
            await _playerService.MapDecisionToPlayer(playerId, model);
            //return CreatedAtAction(
            //    "Get",
            //    new { id = adventureId },
            //    model.DecisionQuery
            //    );
            return Ok(new { id = playerId });
        }
    }
}
