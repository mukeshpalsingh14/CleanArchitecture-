using Order.Application.Interface.IServices;
using OrderApp.Controllers;
using Order.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Order.Domain.Entities;
using Order.Application.Dtos.Order;

namespace OrderApp.Tests.Controller
{
    public class OrderControllerTests
    {
        [Fact]
        public void OrderController_AddOrder_SaveResult()
        {
            // Arrange
            var orderServiceMock = new Mock<IOrderService>();
            var orderProcessor = new OrderController(orderServiceMock.Object);
            var order = new OrderDTO { TotalPrice=100,ProductId=1,UserId=1};

            // Act
            orderProcessor.AddOrder(order);

            // Assert
            orderServiceMock.Verify(x => x.ICreateOrder(It.IsAny<OrderDTO>()), Times.Once);

        }

        //[Fact]
        //public void DisplayOrder_Should_Return_Order()
        //{
        //    // Arrange
        //    int orderId = 1; 
            
        //    var expectedOrder = new OrdersDTO { Id = orderId, ProductName = "Test Product" , FirstName="test",UserId=1,TotalPrice=100,ProductId=1,Email="test@test.com"};

        //    var orderServiceMock = new Mock<IOrderService>();
        //    orderServiceMock.Setup(repo => repo.IDisplayOrderByOrderId(orderId)).Returns(expectedOrder);

        //    var orderService = new IOrderService(orderServiceMock.Object);

        //    //Act
        //   var result = orderService.IDisplayOrderByOrderId(orderId);

        //    //Assert
        //    Assert.Equal(expectedOrder, result.Result);
        //}
    }
}
