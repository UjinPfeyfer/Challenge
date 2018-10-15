using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge24.Models.ChallengeModels
{
    public class OutlineUser
    {
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int Day { get; set; }
        public int OutlineId { get; set; }
        public Outline Outline { get; set; }
        
        
    }
}
