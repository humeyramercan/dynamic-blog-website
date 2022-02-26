using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISubscribeMailService
    {
        List<SubscribeMail> SubscribeMailList();
        void SubscribeMailnDelete(SubscribeMail subscribeMail);
        void SubscribeMailUpdate(SubscribeMail subscribeMail);
        void SubscribeMailInsert(SubscribeMail subscribeMail);
        SubscribeMail SubscribeMailGetById(int id);
    }
}
