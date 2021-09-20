using System.Collections.Generic;
using Q5Api.Models;

namespace Q5Api.Repositories
{
    public interface IQ5ApiRepo
    {
        IEnumerable<Queue> GetAllQueues();
        Queue GetQueueById(int id);
    }
}