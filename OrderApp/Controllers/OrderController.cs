
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Order.Application.Dtos.Order;

using Order.Application.Interface.IServices;

using OrderApp.Middleware;

using System.Collections.Concurrent;


namespace OrderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class OrderController : ControllerBase
    {
        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("addorder")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderModel)
        {

            if (orderModel == null)
                throw new BadRequestException("Order is not passed");

            await _orderService.ICreateOrder(orderModel);

            var orderQueueList = _orderService.IQueuedOrder();

            OrderQueue(orderQueueList);

            return Ok("successfully done.");
        }

       


        [HttpGet("orders")]
        public async Task<IActionResult> DisplayAllOrders()
        {

                var list = await _orderService.IDisplayOrders();
            if (list.Count == 0)
                throw  new NotFoundException("Orders are not found.");
            return Ok(list);
           
        }

        [HttpGet("order/id")]
        public async Task<IActionResult> DisplayOrder(int orderId)
        {

                var orderModel = await _orderService.IDisplayOrderByOrderId(orderId);
                if (orderModel==null)
                throw new NotFoundException("Order not found.");
            return Ok(orderModel);
           
        }


        private void OrderQueue(Task<List<OrdersDTO>> orderQueueList)
        {
            ConcurrentQueue<OrdersDTO> queue = new ConcurrentQueue<OrdersDTO>();
            foreach (var order in orderQueueList.Result)
            {
                queue.Enqueue(order);
            }
            // Create a ConcurrentBag to store the items
            ConcurrentBag<OrdersDTO> bag = new ConcurrentBag<OrdersDTO>();

            // Start a task to move items from the queue to the bag
            Task moverTask = Task.Run(() =>
            {
                OrdersDTO item;
                while (queue.TryDequeue(out item))
                {
                    bag.Add(item);
                    _orderService.IUpDateOrderById(item.Id);
                }
            });

            // Wait for the mover task to complete
            moverTask.Wait();
        }

    }
}
