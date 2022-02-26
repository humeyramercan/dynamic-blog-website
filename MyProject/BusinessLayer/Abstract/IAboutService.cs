using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> AboutList();
        void AboutDelete(About about);
        void AboutUpdate(About about);
        void AboutInsert(About about);
        About AboutGetById(int id);


    }
}
