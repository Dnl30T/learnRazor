using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository.ICategory;
using learnRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace learnRazor.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db){
            _db = db;
        }

        public void Save() {
            _db.SaveChanges();
        }

        public void Update(Category obj) {
            var ObjFromDb = _db.Category.FirstOrDefault(u => u.Id == obj.Id);
            ObjFromDb.Name = obj.Name;
            ObjFromDb.DisplayOrder = obj.DisplayOrder;

        }
    }
}
