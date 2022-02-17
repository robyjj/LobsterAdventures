using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.Models.Entities
{
    public class AddDecisionModel
    {
        public int AdventureId { get; set; }
        public DecisionQuery DecisionQuery { get;set; }
        public bool IsPositive { get;set;}
    }
}
