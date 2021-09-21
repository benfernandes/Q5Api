using AutoMapper;
using Q5Api.Dtos;
using Q5Api.Models;

namespace Q5Api.Profiles
{
    public class QueuesProfile : Profile
    {
        public QueuesProfile()
        {
            CreateMap<Queue, QueueReadDto>();
            CreateMap<QueueCreateDto, Queue>();
        }
    }
}