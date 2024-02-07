using Core.DTO;
using Core.Models;
using Core.Models.Responses;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ISubscriberService
    {
        Task<BasicResponse<bool>> AddSubscribers(SubscriberDTO subscriber);
        Task<BasicResponse<int>> Login(LoginM login);
       Task<BasicResponse <SubscriberAndCardResponse>> GetCard(int id);

    }
}
