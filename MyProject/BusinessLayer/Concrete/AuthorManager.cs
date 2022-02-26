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
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void AuthorDelete(Author author)
        {
            _authorDal.Delete(author);
        }

        public Author AuthorGetById(int id)
        {
            return _authorDal.Get(x => x.AuthorID == id);
        }

        public Author AuthorGetValuesByMail(string mail)
        {
            return _authorDal.Get(x => x.AuthorMail == mail);
        }

        public Author AuthorGetFirstOrDefaultLogin(Author author)
        {
            return _authorDal.GetFirstOrDefault(x => x.AuthorMail == author.AuthorMail && x.AuthorPassword==author.AuthorPassword);
        }

        public void AuthorInsert(Author author)
        {
            _authorDal.Insert(author);
        }

        public List<Author> AuthorList()
        {
            return _authorDal.List();
        }

        public void AuthorUpdate(Author author)
        {
            _authorDal.Update(author);
        }
    }
}
