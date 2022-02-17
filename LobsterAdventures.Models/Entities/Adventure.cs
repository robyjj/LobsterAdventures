using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.Models.Entities
{
    public  class Adventure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdventureId { get; set; }
        public string Name { get; set; }
        //public Guid DecisionQueryId { get; set; }
        //[NotMapped]
        public ICollection<DecisionQuery> DecisionQueries { get; set; }
    }
}
