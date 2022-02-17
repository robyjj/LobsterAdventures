using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LobsterAdventures.Models.Entities
{
    internal class DecisionTree
    {
        public static DecisionQuery MainDecisionTree()
        {
            //    //Decision 4
            //    var creditBranch = new DecisionQuery
            //    {
            //        Title = "Use credit card",
            //        Test = (client) => client.UsesCreditCard,
            //        Positive = new DecisionResult { Result = true },
            //        Negative = new DecisionResult { Result = false }
            //    };

            //    //Decision 3
            //    var experienceBranch = new DecisionQuery
            //    {
            //        Title = "Have more than 3 years experience",
            //        Test = (client) => client.YearsInJob > 3,
            //        Positive = creditBranch,
            //        Negative = new DecisionResult { Result = false }
            //    };


            //    //Decision 2
            //    var moneyBranch = new DecisionQuery
            //    {
            //        Title = "Earn more than 40k per year",
            //        Test = (client) => client.Income > 40000,
            //        Positive = experienceBranch,
            //        Negative = new DecisionResult { Result = false }
            //    };

            //    //Decision 1
            //    var criminalBranch = new DecisionQuery
            //    {
            //        Title = "Have a criminal record",
            //        Test = (client) => client.CriminalRecord,
            //        Positive = new DecisionResult { Result = false },
            //        Negative = moneyBranch
            //    };

            //    //Decision 0
            //    var trunk = new DecisionQuery
            //    {
            //        Title = "Want a loan",
            //        Test = (client) => client.IsLoanNeeded,
            //        Positive = criminalBranch,
            //        Negative = new DecisionResult { Result = false }
            //    };

            //    return trunk;
            return null;
        }
    }

}
