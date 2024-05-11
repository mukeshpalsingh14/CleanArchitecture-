using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public float TotalPrice { get; set; }
        public virtual Product ProductType { get; set; }
        public virtual RegisterModel UserInfo { get; set; }
    }
}
