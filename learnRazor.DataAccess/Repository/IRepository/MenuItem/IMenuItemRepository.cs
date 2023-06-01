using learnRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learnRazor.DataAccess.Repository.IRepository.IMenuItem {
    public interface IMenuItemRepository : IRepository<MenuItem> {
        void Update(MenuItem obj);
        void Save();
    }
}
