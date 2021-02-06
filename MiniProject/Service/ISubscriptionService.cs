using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProject.Service
{
    public interface ISubscriptionService
    {
        Subscription AddSubscription(Subscription subscription);
        Subscription RemoveSubscription(int drugId);
        List<Subscription> GetAllSubscription();
        Subscription GetSubscriptionDetails(int subscriptionId);
    }
}
