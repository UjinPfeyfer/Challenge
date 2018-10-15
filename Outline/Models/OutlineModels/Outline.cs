using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Challenge24.Models.ChallengeModels
{
    public class Outline
    {
        public int OutlineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CreaterId { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        public ICollection<Commen> Comments { get; set; }
        public ICollection<OutlineUser> OutlineUsers { get; set; }

        public Outline()
        {
            Comments = new List<Commen>();
            OutlineUsers = new List<OutlineUser>();

        }
    }
}
