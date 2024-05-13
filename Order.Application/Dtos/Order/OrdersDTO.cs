using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Dtos.Order
{
    public class OrdersDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public float TotalPrice { get; set; }
        public string ProductName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
    }
}
