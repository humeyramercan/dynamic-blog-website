using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> BlogList();
        List<Blog> GetBlogsByStatusandCategory(int id, bool status);
        List<Blog> GetBlogsByStatus(bool status);
        List<Blog> BlogListGetByCategory(int id);
        List<Blog> BlogListGetByAuthorId(int id);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        void BlogInsert(Blog blog);
        Blog BlogGetById(int id);
        string GetLastBlogImageByCategory(int id);
        DateTime GetLastBlogDateByCategory(int id);
        string GetLastBlogTitleByCategory(int id);
        int GetLastBlogIDByCategory(int id);
        int AuthorIdByBlogsId(int id);
    }
}
