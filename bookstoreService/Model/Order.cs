using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bookstoreService.Model
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public bool IsCancel { get; set; }
        public bool IsPaid { get; set; }
        public List<OrderDetail> Details { get; set; }
    }
}
