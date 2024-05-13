using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Application.Dtos;
using Order.Application.Interface.IServices;
using Order.Domain.Entities;
using Order.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly OrderDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ProductService(OrderDbContext context, IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }
        public async Task<ProductDTO> ICreateProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _appDbContext.Product.AddAsync(product);

            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductsDTO>> IDisplayProducts()
        {
            //List<ProductsDTO> productsDTO = new List<ProductsDTO>();
            //var product = _mapper.Map<Product>(productsDTO);
           var productsDTOs= await _appDbContext.Product.ToListAsync();
            return _mapper.Map<List<ProductsDTO>>(productsDTOs);
        }
    }
}
