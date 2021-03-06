using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.Models.Entities;
using LobsterAdventures.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LobsterAdventures.Controllers
{
    [ApiVersion("1.0")]
    [Route("Decisions")]
    [ApiController]
    public class DecisionController : Controller
    {
        private readonly IDecisionService<DecisionQuery> _decisionService;

        public DecisionController(IDecisionService<DecisionQuery> decisionService)
        {
            _decisionService = decisionService; 
        }

        /// <summary>
        /// Get the questions /decision for an adventure
        /// </summary>
        /// <param name="adventureId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Adventure/{adventureId}")]
        public async Task<ActionResult<Adventure>> GetDecisionQueries(int adventureId)
        {
            var queries = await _decisionService.GetQueriesByAdventureId(adventureId);
            return Ok(queries);
        }

        /// <summary>
        /// Returns the next decision based on the previous answer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("{decisionId:int}/Adventure/{adventureId}/NextDecision/")]
        public async Task<IActionResult> Get(int adventureId, int decisionId, bool isPositive)
        {
            var nextDecisionModel = new NextDecisionModel
            {
                DecisionId = decisionId,
                IsPositive = isPositive
            };
            var nextDecision = await _decisionService.GetNextDecision(nextDecisionModel);
            if (nextDecision == null)
            {
                return NotFound();
            }
            return Ok(nextDecision);
        }
    }
}
