using System;
using System.ComponentModel.DataAnnotations;

namespace MiniProject
{
    public class RefillOrder
    {
        public int RefillOrderId { get; set; }

        public int SubscriptionId { get; set; }

        public int DrugId { get; set; }

        public string DrugName { get; set; }

        public int Quantity { get; set; }

        public string Payment { get; set; }

        public DateTime RefillDate { get; set; }

        public DateTime NextRefillDate { get; set; }

        public int PolicyId { get; set; }

        public int MemberId { get; set; }
    }
}
