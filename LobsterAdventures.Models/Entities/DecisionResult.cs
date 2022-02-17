using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.Models.Entities
{
    public class DecisionResult : Decision
    {
        public bool Result { get; set; }
        public override void Evaluate(Adventure adventure)
        {
            Console.WriteLine("\r\nOFFER A LOAN: {0}", Result ? "YES" : "NO");
        }
    }
}
