using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodTypes { get; set; }

        public EditModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodTypes = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        }
        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid){
                _unitOfWork.FoodType.Update(FoodTypes);
                _unitOfWork.Save();
                TempData["success"] = "Food Type changes saved succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
