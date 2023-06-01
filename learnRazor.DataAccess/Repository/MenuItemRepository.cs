using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository.IFoodType;
using learnRazor.DataAccess.Repository.IRepository.IMenuItem;
using learnRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnRazor.DataAccess.Repository {
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository {

        private readonly ApplicationDbContext _db;

        public MenuItemRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
        public void Save() {
            _db.SaveChanges();
        }

        public void Update(MenuItem obj) {
            var ObjFromDb = _db.MenuItem.FirstOrDefault(u => u.Id == obj.Id);
            ObjFromDb.Name = obj.Name;
            ObjFromDb.Description = obj.Description;
            ObjFromDb.Price = obj.Price;
            ObjFromDb.CategoryId = obj.CategoryId;
            ObjFromDb.FoodTypeId = obj.FoodTypeId;
            if(ObjFromDb.ImageUrl == null) {
                ObjFromDb.ImageUrl = obj.ImageUrl;
            }
        }
    }
}
