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
        public List<ProductViewModel> GetPoducts()
        {
            return _productsRepository.GetProduct();
        }
    }
}
