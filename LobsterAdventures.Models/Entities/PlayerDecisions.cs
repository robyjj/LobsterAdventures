using System.ComponentModel.DataAnnotations.Schema;

namespace LobsterAdventures.Models.Entities
{
    public class PlayerDecisions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PlayerId { get; set; }   
        public int DecisionId { get; set; }
        public DecisionQuery DecisionQueries { get; set; }
        public bool IsPositive { get; set; }
        public int AdventureId { get; set; }
    }
}
