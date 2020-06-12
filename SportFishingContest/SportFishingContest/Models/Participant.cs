using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Models
{
    public class Participant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Contest Contest { get; set; }
        public Guid ContestId { get; set; }
    }
}
