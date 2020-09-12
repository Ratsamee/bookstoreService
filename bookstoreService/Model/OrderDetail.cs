using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreService.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string BookId { get; set; }
        public int Qty { get; set; }
        public decimal Prices { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsCancel { get; set; }
    }
}
