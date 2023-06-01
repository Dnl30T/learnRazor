using learnRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnRazor.DataAccess.Repository.IRepository.IFoodType {
    public interface IFoodTypeRepository : IRepository<FoodType>{
        void Update(FoodType obj);
        void Save();
    }
}
