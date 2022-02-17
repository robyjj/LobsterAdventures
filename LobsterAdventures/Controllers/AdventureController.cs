using LobsterAdventures.BLL.Contracts;
using LobsterAdventures.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LobsterAdventures.Controllers
{
    [ApiVersion("1.0")]
    [Route("Adventures")]
    [ApiController]
    public class AdventureController : Controller
    {
        private readonly IAdventureService _adventureService;
   
        public AdventureController(IAdventureService adventureService)
        {
            _adventureService = adventureService;
        }
    
        /// <summary>
        /// Returns the complete list of adventures
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var adventures = await _adventureService.GetAdventures();
            return Ok(adventures);
        }

        /// <summary>
        /// Returns a single adventure information based on the Asset ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var adventure = await _adventureService.GetAdventureById(id);
            if (adventure == null)
            {
                return NotFound();
            }
            return Ok(adventure);
        }

        /// <summary>
        /// Creates an Adventure
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// 
        ///     POST /Adventure
        ///     {                
        ///       "Name": "Adventure 1"
        ///     }
        /// </remarks>
        /// <param name="adventure"></param>        
        [HttpPost]
        public async Task<ActionResult<Adventure>> Post([FromBody] Adventure adventure)
        {
            await _adventureService.CreateAdventure(adventure);
            return CreatedAtAction(
                "Get",
                new { id = adventure.AdventureId },
                adventure
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adventureId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{adventureId}/Decision")]
        public async Task<ActionResult<Adventure>> GetDecisionQueries(int adventureId)
        {
            var queries = await _adventureService.GetQueriesByAdventureId(adventureId);
            return Ok(queries);
        }

        /// <summary>
        /// Adds a Decision to an Adventure
        /// </summary>
        /// <remarks>
        /// Sample request:        
        /// 
        ///     POST /Adventure/1/Decision
        ///     
        ///      {
        ///        "AdventureId" : 2,
        ///        "ParentId" : null,
        ///        "Title": "Are you Ready to start on your adventure"
        ///      }
        ///     
        /// </remarks>
        [HttpPost]
        [Route("{adventureId}/Decision")]
        public async Task<ActionResult<Adventure>> Post( int adventureId, [FromBody] AddDecisionModel model)
        {
            await _adventureService.AddDecision(adventureId, model);
            return CreatedAtAction(
                "Get",
                new { id = adventureId },
                model.DecisionQuery
                );
        }
    }
}
