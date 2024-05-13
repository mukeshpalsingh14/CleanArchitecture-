using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Dtos
{
    public class ProductDTO
    {
       
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }

    public class ProductsDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}
