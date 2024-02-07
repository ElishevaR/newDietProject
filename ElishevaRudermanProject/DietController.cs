using BL;
using Core.DTO;
using Core.Models;
using Core.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietController : ControllerBase
    {
        readonly ISubscriberService _subscribeService;
        public DietController(ISubscriberService subscriberService)
        {
            _subscribeService = subscriberService;
        }

        [HttpPost]
        [Route("AddSubscriber")]

        public async Task<ActionResult<BasicResponse<bool>>> Post(SubscriberDTO subscriber)
        {

          var response= await _subscribeService.AddSubscribers(subscriber);
            if(response.succeed==false)
                return BadRequest(response);
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]

        public async Task<ActionResult<BasicResponse<int>>> Post(LoginM login)
        {
            var response= await _subscribeService.Login(login);
            if (response.succeed == false)
                return BadRequest(response);
            return Ok(response);

        }
        [HttpGet]
        [Route("GetCardById")]
        public async Task<ActionResult<BasicResponse<SubscriberAndCardResponse>>> Get(int id)
        {
            var response= await _subscribeService.GetCard(id);
            if (response.succeed == false)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
