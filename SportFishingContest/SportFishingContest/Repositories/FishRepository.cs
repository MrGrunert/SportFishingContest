using SportFishingContest.Data;
using SportFishingContest.Interfaces;
using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Repositories
{
    public class FishRepository : IFishRepository
    {
        private ApplicationDbContext _context;

        public FishRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Fish Add(Fish addFish)
        {
            _context.Add(addFish);
            return addFish;
        }

       

        public void DeleteFish(Fish delete)
        {
            _context.Remove(delete);
        }

        public IEnumerable<Fish> GetAllFishes()
        {
            return _context.Fishes.ToList();
        }

        public Fish GetFishById(Guid id)
        {
            return _context.Fishes.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fish> GetFishByParticipantId(Guid id)
        {
            return _context.Fishes.Where(p => p.ParticipantId == id).ToList();
        }

        public void UpdateFish(Fish update)
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

            _context.Fishes.Update(update);
            _context.SaveChanges();
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
