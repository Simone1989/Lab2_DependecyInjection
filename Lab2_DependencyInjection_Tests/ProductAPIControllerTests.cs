using Lab2_DependecyInjection.Controllers;
using Lab2_DependecyInjection.Models;
using Moq;
using Xunit;

namespace Lab2_DependencyInjection_Tests
{
    public class ProductAPIControllerTests
    {
        [Fact]
        public void GetAllData_ShouldCallGetAllData()
        {
            var mockRequest = new Mock<IApiRequestSend<Product>>();
            var productController = new ProductAPIController(mockRequest.Object);

            var products = productController.GetAllProducts();

            mockRequest.Verify(m => m.GetAllData(), Times.Once());

        }
    }
}
