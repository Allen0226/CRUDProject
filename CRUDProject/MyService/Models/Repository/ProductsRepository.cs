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
        //取得編輯商品資訊
        public EditInfoViewModel GetEditProduct(int ProductId)
        {
            return _northWind.MyProducts.Where(p => p.ProductId == ProductId).Select(p => new EditInfoViewModel()
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Price = p.UnitPrice,
                Stock = p.UnitsInStock
            }).First();
        }
        //編輯商品
        public bool EditProduct(EditInfoViewModel EditProduct)
        {
            var EditItem = _northWind.MyProducts.FirstOrDefault(p => p.ProductId == EditProduct.Id);
            EditItem.ProductName = EditProduct.Name;
            EditItem.UnitPrice = EditProduct.Price;
            EditItem.UnitsInStock = EditProduct.Stock;
            EditItem.LaunchDate = DateTime.Now;
            try
            {
                _northWind.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        //刪除商品
        public bool DeleteProduct(int ProductId)
        {
            var DeleteItem = _northWind.MyProducts.FirstOrDefault(p => p.ProductId == ProductId);      
            try
            {
                _northWind.Remove(DeleteItem);
                _northWind.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
