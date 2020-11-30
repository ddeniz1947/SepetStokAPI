using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SepetStokProject.Business.Abstract;
using SepetStokProject.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SepetStokProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : Controller
    {
        private IStockClassService _stockClassService;
        public StockController(IStockClassService stockClassService)
        {
            _stockClassService = stockClassService;
        }

        [HttpGet]
        public List<StockClass> GetStockAll()
        {
            return _stockClassService.GetAll();
        }

        [HttpGet("{productId}")]
        public StockClass GetStockByProductId(int productId)
        {
            return _stockClassService.GetStockByProductId(productId);
        }

        [HttpPost]
        public IActionResult AddStock(int productid, int stockcount)
        {
            return Json(_stockClassService.AddStockByProductId(productid, stockcount));
        }
    }
}
