using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SportFishingContest.Interfaces
{
    public interface IContestRepository
    {
        Contest Add(Contest addContest);
        Contest GetContestById(Guid id);
        void UpdateContest(Contest update);
        void DeleteContest(Contest delete);
        IEnumerable<Contest> GetAllContests();
        void Commit();

    }
}
