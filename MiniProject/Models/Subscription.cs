﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MiniProject
{
    public class Subscription
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }

        public int SubscriptionId { get; set; }

        public int MemberId { get; set; }

        public string MemberLocation { get; set; }

        public DateTime SubscriptionDate { get; set; }

        public int PrescriptionId { get; set; }

        public string RefillOccurrence { get; set; }
    }
}
