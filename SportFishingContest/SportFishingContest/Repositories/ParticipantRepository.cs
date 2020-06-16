using SportFishingContest.Data;
using SportFishingContest.Interfaces;
using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private ApplicationDbContext _context;

        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Participant Add(Participant addParticipant)
        {
            _context.Add(addParticipant);
            return addParticipant;
        }

        public void DeleteParticipant(Participant delete)
        {
            _context.Remove(delete);
        }

        public IEnumerable<Participant> GetAllParticipants()
        {
            return _context.Participants.ToList();
        }

        public Participant GetParticipantById(Guid id)
        {
            return _context.Participants.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateParticipant(Participant update)
        {
            if (update == null)
            {
                var error = "An army of monkies broke the website...";
                throw new ArgumentNullException(error);
            }
            if (update.Id == Guid.Empty)
            {
                throw new ArgumentException($"Catch id cannot be 0! {update.Id}");
            }

            _context.Participants.Update(update);
            _context.SaveChanges();
        }
        public IEnumerable<Participant> GetParticipantsByContestId(Guid id)
        {
            return _context.Participants.Where(p => p.ContestId == id).ToList();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

      
    }
}
