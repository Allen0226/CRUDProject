using MyService.Models.ViewModels;

namespace MyService.Models.Repository
{
    public class ProductsRepository
    {
        private readonly NorthWindContext _northWind;

        public ProductsRepository(NorthWindContext northWind)
        {
            _northWind = northWind;
        }
        //取得商品資訊
        public List<ProductViewModel> GetProduct()
        {
            return _northWind.MyProducts.Select(p => new ProductViewModel()
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                Price = p.UnitPrice,
                Stock = p.UnitsInStock,
                LaunchDate = p.LaunchDate.ToString("G")
            }).ToList();
        }
        //新增商品
        public bool CreateProduct(CreatePorductViewModel NewProduct)
        {
            var item = new MyProduct()
            {
                ProductName = NewProduct.ProductName,
                UnitPrice = NewProduct.Price,
                UnitsInStock = NewProduct.Stock,
                LaunchDate = DateTime.Now,
            };
            _northWind.Add(item);
            try
            {
                _northWind.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
