using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {

        List<Category> CategoryList();
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
        void CategoryInsert(Category category);
        List<Category> CategoryGetByStatus(bool status);
        Category CategoryGetById(int id);
    }
}
