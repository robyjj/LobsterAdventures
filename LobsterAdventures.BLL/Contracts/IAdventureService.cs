using LobsterAdventures.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.BLL.Contracts
{
    public interface IAdventureService
    {
        Task<IEnumerable<Adventure>> GetAdventures();
        Task<Adventure> GetAdventureById(int id);
        Task CreateAdventure(Adventure Adventure);
        Task AddDecision(int adventureId, AddDecisionModel model);        
    }
}
