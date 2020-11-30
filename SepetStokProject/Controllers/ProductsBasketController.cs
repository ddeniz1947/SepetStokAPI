using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SepetStokProject.API.ViewModels;
using SepetStokProject.Business.Abstract;
using SepetStokProject.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SepetStokProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsBasketController : Controller
    {
        private IProductsBasketService _productsBasketService;
        
        public ProductsBasketController(IProductsBasketService productsBasketService)
        {
            _productsBasketService = productsBasketService;
        }
        // GET: api/<ProductsBasketController>
        [HttpGet]
        public JsonResult GetBasketAll()
        {
            return Json(_productsBasketService.GetAll());
        }

        // GET api/<ProductsBasketController>/5
        [HttpGet("{userId}")]
        public List<ProductsBasket> GetBasketFromID(int userId)
        {
            return _productsBasketService.GetBasketDataByUserId(userId);

        }


        // POST api/<ProductsBasketController>
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductsBasketViewModel model)
        {
            ProductsBasket productsBasket = new ProductsBasket();
            productsBasket.Name = model.Name;
            productsBasket.ImageUrl = model.imageurl;
            productsBasket.Description = model.Description;
            productsBasket.Category = model.Category;
            productsBasket.Price = model.Price;
            productsBasket.UserID = model.Userid;
            productsBasket.ProductId = model.productid;
            productsBasket.ProductCount = model.productcount;


            return Json(_productsBasketService.AddProductByCount(productsBasket));
        }



        // DELETE api/<ProductsBasketController>
        [HttpDelete]
        public IActionResult DeleteProduct(int userid , int productid,int productcount)
        {
            return  Json(_productsBasketService.DeleteByProductId(userid, productid, productcount));
        }
    }
}
