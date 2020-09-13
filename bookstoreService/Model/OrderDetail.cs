using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bookstoreService.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string BookId { get; set; }
        [Range(0, 100)]
        public int Qty { get; set; }
        [Range(0, 999.99)]
        public decimal Prices { get; set; }
        public string CoverImageUrl { get; set; }
        public bool IsCancel { get; set; }
    }
}
