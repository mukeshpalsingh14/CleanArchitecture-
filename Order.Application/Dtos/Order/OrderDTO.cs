using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Dtos.Order
{
    public class OrderDTO
    {
       // public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public float TotalPrice { get; set; }
    }
}
