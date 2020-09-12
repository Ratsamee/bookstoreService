using System;
using System.Collections.Generic;

namespace bookstoreService.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCancel { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}
