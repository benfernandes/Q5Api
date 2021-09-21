using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Q5Api.Dtos;
using Q5Api.Models;
using Q5Api.Repositories;

namespace Q5Api.Controllers
{
    [Route("api/queues")]
    [ApiController]
    public class QueuesController : ControllerBase
    {
        private readonly IQ5ApiRepo _repository;
        private readonly IMapper _mapper;

        public QueuesController(IQ5ApiRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/queues
        [HttpGet]
        public ActionResult<IEnumerable<QueueReadDto>> GetAllQueues()
        {
            var queueItems = _repository.GetAllQueues();
            return Ok(_mapper.Map<IEnumerable<QueueReadDto>>(queueItems));
        }

        // GET api/queues/{id}
        [HttpGet("{id}")]
        public ActionResult<QueueReadDto> GetQueueById(int id)
        {
            var queueItem = _repository.GetQueueById(id);

            if (queueItem != null)
            {
                return Ok(_mapper.Map<QueueReadDto>(queueItem));
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/queues
        [HttpPost]
        public ActionResult<QueueReadDto> CreateQueue(QueueCreateDto queueCreateDto)
        {
            var queueModel = _mapper.Map<Queue>(queueCreateDto);
            // TODO - Add validation checks
            _repository.CreateQueue(queueModel);
            _repository.SaveChanges();

            return Ok(queueModel);
        }
    }
}