using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject.Repository;
using MiniProject.Service;

namespace MiniProject.Controllers
{
    ///[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        readonly ISubscriptionService _subscriptionService;
        public SubscribeController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public List<Subscription> GetAllSubscriptionDetails()
        {

            var details = _subscriptionService.GetAllSubscription();
            if (details != null)
            {
                return details;
            }

            return null;

        }

        [HttpGet("{id}")]
        public Subscription GetSubscriptionDetails(int id)
        {

            var details = _subscriptionService.GetSubscriptionDetails(id);
            if (details != null)
            {
                return details;
            }

            return null;

        }

        //Checks Drugs and Adds details.
        [HttpPost]
        public IActionResult AddSubscription(Subscription subscription)
        {
            //Subscription s = new Subscription();
            SubscriptionHelper.SessionToken = this.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);

            var item = _subscriptionService.AddSubscription(subscription);
            if (item == null) { 
            return Ok("Drug Available");
        }
            return BadRequest("Cannot be subscribed, Drug Not Available");


            
        }

        // Checks Amount Due and Unsubscribes, if NO dues
        [HttpGet("{id}")]
        public IActionResult RemoveSubscription(int drugId)
        {
            SubscriptionHelper.SessionToken = this.HttpContext.Request.Headers["Authorization"].ToString().Substring(7);
            var item = _subscriptionService.RemoveSubscription(drugId);
            if(item != null)
            {
                return Ok("Unsubscribed");
            }
            return BadRequest("please pay your dues before you unsubscribe");
        }

    }
}

