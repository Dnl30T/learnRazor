using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }

        public CreateModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {
            if(Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(string.Empty, "The Display Order cannot exactly match the name.");
            }
            if (ModelState.IsValid){
                _unitOfWork.Category.Add(Category);
                _unitOfWork.Save();
                TempData["success"] = "Category created succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
