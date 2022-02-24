using LobsterAdventures.Models.Entities;
using System.Collections.Generic;

namespace LobsterAdventures.Models.Models
{
    public class PlayerPathModel
    {
        public int PlayerId { get; set; }
        public int AdventureId { get; set; }
        public List<QuestionsModel> Questions { get; set; }
    }

}
