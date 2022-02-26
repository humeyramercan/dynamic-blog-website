using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        List<T> ListGetById(Expression<Func<T, bool>> filter);
        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        T Get(Expression<Func<T, bool>> filter);
       T GetFirstOrDefaultDesc(Expression<Func<T, bool>> filter);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

    }
}
