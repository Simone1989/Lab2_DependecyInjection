using Lab2_DependecyInjection.Models;
using Microsoft.AspNetCore.Mvc;
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
    }
}