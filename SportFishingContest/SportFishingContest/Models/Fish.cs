using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Models
{
    public class Fish
    {
        public Guid Id { get; set; }
        public int Length { get; set; }
        public Participant participant { get; set; }
        public Guid ParticipantId { get; set; }

    }
}
