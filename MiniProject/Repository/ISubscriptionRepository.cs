using System;
using System.Collections.Generic;

namespace MiniProject.Repository
{
    public interface ISubscriptionRepository
    {
        
        
        Subscription AddSubscription(Subscription subscription);
        Subscription RemoveSubscription(int drugId);
        List<Subscription> GetAllSubscription();
        Subscription GetSubscriptionDetails(int subscriptionId);



    }
}
