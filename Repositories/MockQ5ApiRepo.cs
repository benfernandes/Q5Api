using System.Collections.Generic;
using Q5Api.Models;

namespace Q5Api.Repositories
{
    public class MockQ5ApiRepo : IQ5ApiRepo
    {
        public IEnumerable<Queue> GetAllQueues()
        {
            var queues = new List<Queue>
            {
                new Queue{Id = 0, Name = "Test queue 1"},
                new Queue{Id = 1, Name = "Test queue 2"},
                new Queue{Id = 2, Name = "Test queue 3"}
            };

            return queues;
        }

        public Queue GetQueueById(int id)
        {
            return new Queue { Id = 0, Name = "Test queue" };
        }
    }
}