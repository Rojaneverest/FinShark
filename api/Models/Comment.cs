using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int? StockId { get; set; }
        public Stocks? Stock { get; set; }

    }
}