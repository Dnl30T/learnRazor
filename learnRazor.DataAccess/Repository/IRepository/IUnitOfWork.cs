using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using learnRazor.DataAccess.Repository.IRepository.ICategory;
using learnRazor.DataAccess.Repository.IRepository.IFoodType;
using learnRazor.DataAccess.Repository.IRepository.IMenuItem;

namespace learnRazor.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable{

        ICategoryRepository Category { get; }
        IFoodTypeRepository FoodType { get; }
        IMenuItemRepository MenuItem { get; }

        void Save();
    }
}
