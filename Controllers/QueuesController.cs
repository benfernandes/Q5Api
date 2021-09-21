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
        private readonly IQ5ApiRepo _repository;

        public QueuesController(IQ5ApiRepo repository)
        {
            _repository = repository;
        }

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

            if (queueItem != null)
            {
                return Ok(queueItem);
            }
            else
            {
                return NotFound();
            }
        }
    }
}