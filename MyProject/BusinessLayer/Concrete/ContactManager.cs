using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public Contact ContactGetById(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public void ContactInsert(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public List<Contact> ContactList()
        {
            return _contactDal.List();
        }

        public void ContactUpdate(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
