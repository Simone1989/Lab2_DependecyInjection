using Lab2_DependecyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Lab2_DependecyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : Controller
    {
        private readonly IApiRequestSend<Product> requestSend;

        public ProductAPIController(IApiRequestSend<Product> requestSend)
        {
            this.requestSend = requestSend;
        }

        public virtual IEnumerable<Product> GetAllProducts()
        {
            return requestSend.GetAllData();
        }

        public void AddNewProduct(Product product)
        {
            requestSend.AddEntity(product);
        }

        public void EditProduct(int id, Product product)
        {
            requestSend.ModifyEntity(id, product);
        }

        public void DeleteProduct(Product product)
        {
            requestSend.DeleteEntity(product);
        }
    }
}