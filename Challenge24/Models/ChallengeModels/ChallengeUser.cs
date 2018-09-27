using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge24.Models.ChallengeModels
{
    public class ChallengeUser
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
    }
}
