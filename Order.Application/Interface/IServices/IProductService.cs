using Order.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Interface.IServices
{
    public interface IProductService
    {
        Task<ProductDTO> ICreateProduct(ProductDTO userDTO);

        Task<List<ProductsDTO>> IDisplayProducts();
    }
}
