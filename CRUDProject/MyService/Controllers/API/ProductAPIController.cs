using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyService.Logic;
using MyService.Models;
using MyService.Models.ViewModels;

namespace MyService.Controllers.API
{
    [Route("api/Product/{action}")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly NorthWindContext _northWind;
        private readonly IcommonLogic _commonLogic;

        public ProductAPIController(NorthWindContext northWind, IcommonLogic icommonLogic)
        {
           _northWind = northWind;
           _commonLogic = icommonLogic;
        }
        [HttpGet]
        public List<ProductViewModel> GetProductInfo()
        {
            return _commonLogic.GetPoducts();
        }
        [HttpPost]
        public bool CreateProduct(CreatePorductViewModel NewProduct)
        {
            return _commonLogic.SetNewProducts(NewProduct);
        }
    }
}
