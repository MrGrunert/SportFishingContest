using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.Interfaces
{
    public interface IFishRepository
    {
        Fish Add(Fish addFish);
        Fish GetFishById(Guid id);
        void UpdateFish(Fish update);
        void DeleteFish(Fish delete);
        IEnumerable<Fish> GetAllFishes();
        IEnumerable<Fish> GetFishByParticipantId(Guid id);
        void Commit();
    }
}
