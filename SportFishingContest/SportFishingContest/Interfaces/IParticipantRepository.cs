using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Interfaces
{
    public interface IParticipantRepository
    {
        Participant Add(Participant addParticipant);
        Participant GetParticipantById(Guid id);
        void UpdateParticipant(Participant update);
        void DeleteParticipant(Participant delete);
        IEnumerable<Participant> GetAllParticipants();
        IEnumerable<Participant> GetParticipantsByContestId(Guid id);
        void Commit();
    }
}


