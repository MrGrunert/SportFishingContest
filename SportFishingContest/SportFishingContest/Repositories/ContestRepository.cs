using Microsoft.EntityFrameworkCore;
using SportFishingContest.Data;
using SportFishingContest.Interfaces;
using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Repositories
{
    public class ContestRepository : IContestRepository
    {
        private ApplicationDbContext _context;

        public ContestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contest Add(Contest addContest)
        {
            _context.Add(addContest);
            return addContest;
        }

        public void DeleteContest(Contest delete)
        {
            _context.Remove(delete);
        }

        public IEnumerable<Contest> GetAllContests()
        {
            return _context.Contests.ToList();
        }

        public Contest GetContestById(Guid id)
        {
            return _context.Contests.FirstOrDefault(c => c.Id == id);
        }

        public void UpdateContest(Contest update)
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

            _context.Contests.Update(update);
            _context.SaveChanges();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
