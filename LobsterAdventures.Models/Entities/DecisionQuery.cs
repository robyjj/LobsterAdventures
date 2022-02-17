using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.Models.Entities
{
    public class DecisionQuery // : Decision
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        
        public int? PositiveId { get; set; }
        //[NotMapped]
        [ForeignKey("PositiveId")]
        public DecisionQuery Positive { get; set; }
        //[NotMapped]
        public int? NegativeId { get; set; }
        //[NotMapped]
        [ForeignKey("NegativeId")]
        public DecisionQuery Negative { get; set; }

        [ForeignKey("AdventureId")]
        public Adventure Adventure { get; set; }        
        
        public int AdventureId { get; set; }

        public DecisionQuery()
        {

        }
        public DecisionQuery(int id, string title)
        {
            Id = id;
            Title = title;
        }
        //public Func<Adventure, bool> Test { get; set; }

        //public override void Evaluate(Adventure client)
        //{
        //    bool result = this.Test(client);
        //    string resultAsString = result ? "yes" : "no";

        //    Console.WriteLine($"\t- {this.Title}? {resultAsString}");

        //    if (result) this.Positive.Evaluate(client);
        //    else this.Negative.Evaluate(client);
        //}
    }
}
