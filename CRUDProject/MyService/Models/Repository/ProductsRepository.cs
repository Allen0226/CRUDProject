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
    }
}
