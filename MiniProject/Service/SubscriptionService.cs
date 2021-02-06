using MiniProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Service
{
    public class SubscriptionService : ISubscriptionService
    {

        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }
        public Subscription AddSubscription(Subscription subscription)
        {
            return _subscriptionRepository.AddSubscription(subscription);
        }

        public List<Subscription> GetAllSubscription()
        {
            return _subscriptionRepository.GetAllSubscription();
        }

        public Subscription GetSubscriptionDetails(int subscriptionId)
        {
            return _subscriptionRepository.GetSubscriptionDetails(subscriptionId);
        }

        public Subscription RemoveSubscription(int drugId)
        {
            return _subscriptionRepository.RemoveSubscription(drugId); 
        }
    }
}
