using MyService.Models.ViewModels;

namespace MyService.Logic
{
    public interface IcommonLogic
    {
        public List<ProductViewModel> GetPoducts();
        public bool SetNewProducts(CreatePorductViewModel Product);
        public EditInfoViewModel GetEditProducts(int index);
        public bool SetEditProducts(EditInfoViewModel Product);
        public bool DeleteProducts(int index);
    }
}
