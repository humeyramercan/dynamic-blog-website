﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> ContactList();
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
        void ContactInsert(Contact contact);
        Contact ContactGetById(int id);
    }
}
