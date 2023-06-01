using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.FoodTypes {
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodTypes { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodTypes = _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id==id);
        }
        public async Task<IActionResult> OnPost() {
            var foodTypeFromDb = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodTypes.Id);
            if (foodTypeFromDb != null) {
                _unitOfWork.FoodType.Remove(foodTypeFromDb);
                _unitOfWork.Save();
                TempData["success"] = "Food Type deleted succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
