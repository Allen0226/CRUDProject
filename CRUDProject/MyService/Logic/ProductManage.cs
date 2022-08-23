using MyService.Models.Repository;
using MyService.Models.ViewModels;

namespace MyService.Logic
{
    public class ProductManage : IcommonLogic
    {
        private readonly ProductsRepository _productsRepository;

        public ProductManage(ProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        //取得商品資訊
        public List<ProductViewModel> GetPoducts()
        {
            return _productsRepository.GetProduct();
        }
        //新增商品
        public bool SetNewProducts(CreatePorductViewModel Product)
        {
            return _productsRepository.CreateProduct(Product);
        }
    }
}
