using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Q5Api.Models;
using Q5Api.Repositories;

namespace Q5Api.Controllers
{
    [Route("api/queues")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private readonly MockQ5ApiRepo _repository = new MockQ5ApiRepo();
        // GET api/queues
        [HttpGet]
        public ActionResult<IEnumerable<Queue>> GetAllQueues()
        {
            var queueItems = _repository.GetAllQueues();
            return Ok(queueItems);
        }

        // GET api/queues/{id}
        [HttpGet("{id}")]
        public ActionResult<Queue> GetQueueById(int id)
        {
            var queueItem = _repository.GetQueueById(id);
            return Ok(queueItem);
        }
    }
}