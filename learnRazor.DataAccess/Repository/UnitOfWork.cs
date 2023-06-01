using learnRazor.DataAccess.Data;
using learnRazor.DataAccess.Repository.IRepository;
using learnRazor.DataAccess.Repository.IRepository.ICategory;
using learnRazor.DataAccess.Repository.IRepository.IFoodType;
using learnRazor.DataAccess.Repository.IRepository.IMenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnRazor.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork{
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            FoodType = new FoodTypeRepository(_db);
            MenuItem = new MenuItemRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public IFoodTypeRepository FoodType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }

        public void Dispose() {
            _db.Dispose();
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}
