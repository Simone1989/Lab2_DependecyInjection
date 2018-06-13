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

            productController.GetAllProducts();

            mockRequest.Verify(m => m.GetAllData(), Times.Once());

        }

        [Fact]
        public void AddEntity_ShouldCallAddEntity()
        {
            Product product = new Product(1, "book", 55, 1, "B");
            var mockRequest = new Mock<IApiRequestSend<Product>>();
            var productController = new ProductAPIController(mockRequest.Object);

            productController.AddNewProduct(product);

            mockRequest.Verify(m => m.AddEntity(product), Times.Once());
        }

        [Fact]
        public void ModifyEntity_ShouldCallModifyEntityWithCorrectParameters()
        {
            Product product = new Product(1, "book", 55, 1, "B");
            var mockRequest = new Mock<IApiRequestSend<Product>>();
            var productController = new ProductAPIController(mockRequest.Object);

            productController.EditProduct(product.Id, product);

            mockRequest.Verify(m => m.ModifyEntity(product.Id, It.Is<Product>(p => p.Id == product.Id)), Times.Once());
        }

        [Fact]
        public void DeleteEntity_ShouldCallDeleteEntity()
        {
            Product product = new Product(1, "book", 55, 1, "B");
            var mockRequest = new Mock<IApiRequestSend<Product>>();
            var productController = new ProductAPIController(mockRequest.Object);

            productController.DeleteProduct(product);

            mockRequest.Verify(m => m.DeleteEntity(product), Times.Once());
        }
    }
}
