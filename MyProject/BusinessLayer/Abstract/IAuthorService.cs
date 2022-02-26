using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        List<Author> AuthorList();
        void AuthorDelete(Author author);
        void AuthorUpdate(Author author);
        void AuthorInsert(Author author);
        Author AuthorGetById(int id);
        Author AuthorGetValuesByMail(string mail);
        Author AuthorGetFirstOrDefaultLogin(Author author);
    }
}
