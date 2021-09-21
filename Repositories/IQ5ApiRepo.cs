using System.Collections.Generic;
using Q5Api.Models;

namespace Q5Api.Repositories
{
    public interface IQ5ApiRepo
    {
        bool SaveChanges();
        
        IEnumerable<Queue> GetAllQueues();
        Queue GetQueueById(int id);
        void CreateQueue(Queue queue);
        void UpdateQueue(Queue queue);
        void DeleteQueue(Queue queue);
    }
}