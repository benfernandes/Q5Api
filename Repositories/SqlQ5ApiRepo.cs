using System.Collections.Generic;
using System.Linq;
using Q5Api.Contexts;
using Q5Api.Models;

namespace Q5Api.Repositories
{
    public class SqlQ5ApiRepo : IQ5ApiRepo
    {
        private readonly Q5ApiContext _context;

        public SqlQ5ApiRepo(Q5ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Queue> GetAllQueues()
        {
            return _context.Queues.ToList();
        }

        public Queue GetQueueById(int id)
        {
            return _context.Queues.FirstOrDefault(p => p.Id == id);
        }
    }
}