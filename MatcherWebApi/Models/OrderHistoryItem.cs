﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatcherWebApi.Models
{
    public class OrderHistoryItem
    {
        public int OrderHistoryItemId { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
    }
}