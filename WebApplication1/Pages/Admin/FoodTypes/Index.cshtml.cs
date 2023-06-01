using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            FoodTypes = _unitOfWork.FoodType.GetAll();
        }
    }
}
