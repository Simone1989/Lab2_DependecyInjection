using Lab2_DependecyInjection.Controllers;
using Lab2_DependecyInjection.Models;
using Moq;
using System.Collections.Generic;
using Xunit;
using System.Linq;

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
        public void GetAllData_ShouldReturnListOfProducts()
        {
            var mockRequest = new Mock<IApiRequestSend<Product>>();
            IEnumerable<Product> products = new[]
            {
                new Product(2, "Car", 30000, 2, "A"),
                new Product(3, "Mouse pad", 20, 1, "C")
            };
            var productController = new ProductAPIController(mockRequest.Object);
            mockRequest.Setup(m => m.GetAllData()).Returns(products);

            var actual = mockRequest.Object.GetAllData();
            var expected = products;

            //Assert.Contains(actual, x=> x.Id==)
            //actual.Contains()
            
            Assert.Equal(expected, actual);
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
