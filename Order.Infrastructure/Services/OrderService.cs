using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Order.Application.Dtos;
using Order.Application.Dtos.Order;
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
    public class OrderService: IOrderService
    {
        private readonly OrderDbContext _appDbContext;
        private readonly IMapper _mapper;
        public OrderService(OrderDbContext context, IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }

        public async Task<OrderDTO> ICreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Orders>(orderDTO);
           
            await _appDbContext.Order.AddAsync(order);

            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrdersDTO> IDisplayOrderByOrderId(int Id)
        {
            var ordersDTOs = await _appDbContext.Order.FirstOrDefaultAsync(x=>x.Id == Id);
            return _mapper.Map<OrdersDTO>(ordersDTOs);
        }

        public async Task<List<OrdersDTO>> IDisplayOrders()
        {
            var ordersDTOs = await _appDbContext.Order.ToListAsync();
            return _mapper.Map<List<OrdersDTO>>(ordersDTOs);
        }

        public async Task<List<OrdersDTO>> IQueuedOrder()
        {
            var ordersDTOs = await _appDbContext.Order.Where(x => x.isQrderProcessed == false).ToListAsync();
            return _mapper.Map<List<OrdersDTO>>(ordersDTOs);
        }

        public async Task IUpDateOrderById(int Id)
        {
            var order = await _appDbContext.Order.FirstOrDefaultAsync(x => x.Id == Id);
            if(order != null)
             order.isQrderProcessed=true;
             await _appDbContext.SaveChangesAsync();
            
           
        }
    }
}
