using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.Models.Entities
{
    public abstract class Decision
    {
        public int Id { get; set; }
        public abstract void Evaluate(Adventure adventure);
    }
}
