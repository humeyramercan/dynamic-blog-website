using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> AdminList();
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
        void AdminInsert(Admin admin);
        Admin AdminGetById(int id);
        Admin AdminGetFirstOrDefaultLogin(Admin admin);

    }
}
