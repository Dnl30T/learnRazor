using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.FoodTypes {
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodTypes { get; set; }

        public CreateModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {
            if(FoodTypes.Name == "hamburguer") {
                ModelState.AddModelError(string.Empty, "Hamburguer isn't a food");
            }
            if (ModelState.IsValid){
                _unitOfWork.FoodType.Add(FoodTypes);
                _unitOfWork.Save();
                TempData["success"] = "Food type added succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
