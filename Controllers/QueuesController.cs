using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        [HttpGet("{id}", Name = "GetQueueById")]
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

            var queueReadDto = _mapper.Map<QueueReadDto>(queueModel);

            return CreatedAtRoute(nameof(GetQueueById), new { Id = queueReadDto.Id }, queueReadDto);
        }

        // PATCH api/queues/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateQueue(int id, JsonPatchDocument<QueueUpdateDto> patchDocument)
        {
            var queueModelFromRepo = _repository.GetQueueById(id);
            if (queueModelFromRepo == null)
            {
                return NotFound();
            }

            var queueToPatch = _mapper.Map<QueueUpdateDto>(queueModelFromRepo);
            patchDocument.ApplyTo(queueToPatch, ModelState);
            if (!TryValidateModel(queueToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(queueToPatch, queueModelFromRepo);
            _repository.UpdateQueue(queueModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/queues/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteQueue(int id)
        {
            var queueModelFromRepo = _repository.GetQueueById(id);
            if (queueModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteQueue(queueModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}