﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin AdminGetById(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public void AdminInsert(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public List<Admin> AdminList()
        {
            return _adminDal.List();
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }
        public Admin AdminGetFirstOrDefaultLogin(Admin admin)
        {
            return _adminDal.GetFirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
        }
    }
}
