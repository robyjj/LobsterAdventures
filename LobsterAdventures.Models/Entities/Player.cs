using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LobsterAdventures.Models.Entities
{
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }
        public int AdventureId { get; set; }
        public string Name { get; set; }
        //public ICollection<DecisionQuery> DecisionQueries { get; set; }
        public List<PlayerDecisions> PlayerDecisions { get; set; }
    }
}
