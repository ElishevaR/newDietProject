using AutoMapper;
using Core.DTO;
using Core.Models;
using Core.Models.Responses;
using Data.Model;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubscriberService : ISubscriberService
    {
        readonly ISubscriberRepository _SubscriberRepository;
        readonly IMapper _mapper;
        public SubscriberService(ISubscriberRepository subscriberRepository, IMapper mapper)
        {
            _SubscriberRepository = subscriberRepository;
            _mapper = mapper;
        }

        public async Task<BasicResponse<bool>> AddSubscribers(SubscriberDTO subscriberDTO)
        {
            Subscriber subscriber = _mapper.Map<Subscriber>(subscriberDTO);
            //bool exist = await _SubscriberRepository.GetSubscriberByPassword(subscriber.Password);
           return await _SubscriberRepository.AddSubscriber(subscriber,subscriberDTO.Height);
        }

        public async Task<BasicResponse<int>> Login(LoginM loginM)
        {
           return await _SubscriberRepository.Login(loginM.Password, loginM.Email);
        }

        public async Task<BasicResponse<SubscriberAndCardResponse>> GetCard(int id)
        {
           return await _SubscriberRepository.GetCard(id);
        }
    }
}
