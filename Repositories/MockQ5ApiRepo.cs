using System.Collections.Generic;
using Q5Api.Models;

namespace Q5Api.Repositories
{
    public class MockQ5ApiRepo : IQ5ApiRepo
    {
        public void CreateQueue(Queue queue)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteQueue(Queue queue)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Queue> GetAllQueues()
        {
            var queues = new List<Queue>
            {
                new Queue{Id = 0, Name = "Mock test queue 1"},
                new Queue{Id = 1, Name = "Mock test queue 2"},
                new Queue{Id = 2, Name = "Mock test queue 3"}
            };

            return queues;
        }

        public Queue GetQueueById(int id)
        {
            return new Queue { Id = 0, Name = "Mock test queue" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateQueue(Queue queue)
        {
            throw new System.NotImplementedException();
        }
    }
}