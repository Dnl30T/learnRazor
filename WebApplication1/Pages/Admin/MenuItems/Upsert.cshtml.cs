using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Pages.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment) {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            MenuItem = new MenuItem(); 
        }
        public void OnGet() {
            CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString(),
            });
        }
        public async Task<IActionResult> OnPost() {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(MenuItem.Id == 0) {
                //Create
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images/menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension),
                    FileMode.Create)) {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.ImageUrl = @"\images\menuItems\" + fileName_new + extension;
                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.Save();
            }
            else {

            }
            //return RedirectToPage("./Index");
            return Page();
        }
    }
}
