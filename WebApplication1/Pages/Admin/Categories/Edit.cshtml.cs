using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }

        public EditModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
        }
        public async Task<IActionResult> OnPost() {
            if(Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(string.Empty, "The Display Order cannot exactly match the name.");
            }
            if (ModelState.IsValid){
                _unitOfWork.Category.Update(Category);
                _unitOfWork.Save();
                TempData["success"] = "Category changes saved succesfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
