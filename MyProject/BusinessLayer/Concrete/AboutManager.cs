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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public About AboutGetById(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id);
        }

        public void AboutInsert(About about)
        {
            _aboutDal.Insert(about);
        }

        public List<About> AboutList()
        {
            return _aboutDal.List();
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }

       
    }
}
