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
        //取得要編輯商品資訊
        public EditInfoViewModel GetEditProducts(int index)
        {
            return _productsRepository.GetEditProduct(index);
        }
        //編輯商品
        public bool SetEditProducts(EditInfoViewModel Product)
        {
            return _productsRepository.EditProduct(Product);
        }
        //刪除商品
        public bool DeleteProducts(int index)
        {
            return _productsRepository.DeleteProduct(index);
        }
    }
}
