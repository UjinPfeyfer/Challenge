using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge24.Models.ChallengeModels
{
    public class Commen
    {
        public int CommenId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int OutlineId { get; set; }
        public Outline Outline { get; set; }
        public string CommentText { get; set; }
    }
}
