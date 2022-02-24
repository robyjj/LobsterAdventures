using LobsterAdventures.Models.Entities;

namespace LobsterAdventures.Models.Models
{
    public class PlayerPathModel
    {
        public int PlayerId { get; set; }
        public int AdventureId { get; set; }
        public DecisionQuery DecisionQuery { get; set; }
        public int DecisionQueryId { get; set; }
        public bool IsPositive { get; set; }
    }
}
