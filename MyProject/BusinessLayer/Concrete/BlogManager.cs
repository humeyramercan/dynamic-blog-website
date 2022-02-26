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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Update(blog);
        }


        public Blog BlogGetById(int id)
        {
            return _blogDal.Get(x => x.BlogID == id);
        }

        public void BlogInsert(Blog blog)
        {
            _blogDal.Insert(blog);
        }

        public List<Blog> BlogList()
        {
            return _blogDal.List();
        }
        public List<Blog> BlogListGetByAuthorId(int id)
        {
            return _blogDal.ListGetById(x => x.AuthorID == id);
        }
   


        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public string GetLastBlogTitleByCategory(int id)
        {
            return _blogDal.GetFirstOrDefaultDesc(x => x.CategoryID == id && x.BlogStatus == true).BlogTitle;
        }
        public string GetLastBlogImageByCategory(int id)
        {
            return _blogDal.GetFirstOrDefaultDesc(x => x.CategoryID == id && x.BlogStatus == true).BlogCoverImage;
        }
        public int GetLastBlogIDByCategory(int id)
        {
            return _blogDal.GetFirstOrDefaultDesc(x => x.CategoryID == id && x.BlogStatus == true).BlogID;
        }
        public DateTime GetLastBlogDateByCategory(int id)
        {
            return _blogDal.GetFirstOrDefaultDesc(x => x.CategoryID == id && x.BlogStatus == true).BlogDate;
        }


        public List<Blog> BlogListGetByCategory(int id)
        {
            return _blogDal.ListGetById(x => x.CategoryID == id);
        }

        public List<Blog> GetBlogsByStatusandCategory(int id, bool status)
        {
            return _blogDal.ListGetById(x => x.CategoryID == id).Where(x => x.BlogStatus == status && x.Category.CategoryStatus == true).ToList();
        }
        public int AuthorIdByBlogsId(int id)
        {
            return _blogDal.ListGetById(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
        }

        public List<Blog> GetBlogsByStatus(bool status)
        {
            return _blogDal.ListGetById(x => x.BlogStatus == status).Where(x => x.Category.CategoryStatus == true).ToList();
        }
    }
}

