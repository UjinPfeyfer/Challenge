using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Challenge24.Models.ChallengeModels
{
    public class Challenge
    {
        public int ChallengeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Condition { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }
        public ICollection<ChallengeUser> ChallengeUsers { get; set; }
        
    }
}
