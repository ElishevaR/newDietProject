using Core.Models.Responses;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface ISubscriberRepository
    {
       Task<BasicResponse<bool>> AddSubscriber(Subscriber subscriber,float height);
      // Task< bool> GetSubscriberByPassword(string password);
        public Task<BasicResponse<int>> Login(string password, string email);
        Task<BasicResponse<SubscriberAndCardResponse>> GetCard(int id);

    }
}
