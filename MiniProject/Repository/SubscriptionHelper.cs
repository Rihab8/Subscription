using System;
using System.Collections.Generic;

namespace MiniProject.Repository
{
    public class SubscriptionHelper
    {
        public static string SessionToken;
        public static List<Subscription> SubscriptionDetails = new List<Subscription>
        {  new Subscription
            {
                DrugId=1,
                DrugName="Paracetamol",
                SubscriptionId=1,
                MemberId = 1,
                PrescriptionId = 1,
                MemberLocation = "Hyderabad",
                SubscriptionDate =new DateTime(2021,01,06),
                RefillOccurrence = "Monthly",
            },
            new Subscription
            {
                DrugId=2,
                DrugName="Saridon",
                SubscriptionId=2,
                MemberId = 2,
                PrescriptionId = 2,
                MemberLocation = "Mumbai",
                SubscriptionDate=new DateTime(2020,01,02),
                RefillOccurrence = "Weekly",
            },
        };
       


    }
}
