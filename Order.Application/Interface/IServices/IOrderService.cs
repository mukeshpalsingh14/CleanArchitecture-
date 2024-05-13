using Order.Application.Dtos;
using Order.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Interface.IServices
{
    public interface IOrderService
    {
        Task<OrderDTO> ICreateOrder(OrderDTO userDTO);

        Task<List<OrdersDTO>> IDisplayOrders();

        Task<OrdersDTO> IDisplayOrderByOrderId(int orderId);

        Task<List<OrdersDTO>> IQueuedOrder();

        Task IUpDateOrderById(int Id);
    }
}
