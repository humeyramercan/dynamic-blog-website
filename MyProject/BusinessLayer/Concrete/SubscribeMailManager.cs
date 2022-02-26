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
    public class SubscribeMailManager : ISubscribeMailService
    {
        ISubscribeMailDal _subscribeMailDal;

        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMailDal = subscribeMailDal;
        }

        public SubscribeMail SubscribeMailGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SubscribeMailInsert(SubscribeMail subscribeMail)
        {
            _subscribeMailDal.Insert(subscribeMail);
        }

        public List<SubscribeMail> SubscribeMailList()
        {
            throw new NotImplementedException();
        }

        public void SubscribeMailnDelete(SubscribeMail subscribeMail)
        {
            throw new NotImplementedException();
        }

        public void SubscribeMailUpdate(SubscribeMail subscribeMail)
        {
            throw new NotImplementedException();
        }
    }
}
