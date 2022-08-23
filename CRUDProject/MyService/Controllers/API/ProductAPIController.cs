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
        //取得商品
        [HttpGet]
        public List<ProductViewModel> GetProductInfo()
        {
            return _commonLogic.GetPoducts();
        }
        //新增商品
        [HttpPost]
        public bool CreateProduct(CreatePorductViewModel NewProduct)
        {
            return _commonLogic.SetNewProducts(NewProduct);
        }
        //取得編輯商品
        [HttpGet]
        [Route("{ProductId}")]
        public EditInfoViewModel GetEditProductInfo(int ProductId)
        {
            return _commonLogic.GetEditProducts(ProductId);
        }
        //編輯商品
        [HttpPut]
        public bool EditProduct(EditInfoViewModel EditProduct)
        {
            return _commonLogic.SetEditProducts(EditProduct);
        }
    }
}
