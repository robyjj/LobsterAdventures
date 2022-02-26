using LobsterAdventures.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.DAL.Contracts
{
    public interface IAdventureRepository<T>
    {
        Task<IEnumerable<T>> GetAdventures();        
        Task<T> GetAdventureById(int id);
        Task CreateAdventure(T Adventure);
        Task UpdateAdventure(int AdventureID, T Adventure);
        Task<T> DeleteAdventure(int id);
        Task<List<T>> DeleteMultiple(int[] ids);

        Task AddDecision(int AdventureID, AddDecisionModel model);
        
    }
}
