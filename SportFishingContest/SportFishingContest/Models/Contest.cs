using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Models
{
    public class Contest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Participant> Participants { get; set; }
    }
}
