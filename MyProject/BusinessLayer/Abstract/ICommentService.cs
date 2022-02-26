using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> CommentList();
        List<Comment> CommentListByBlogId(int id);
        void CommentDelete(Comment comment);
        void CommentUpdate(Comment comment);
        void CommentInsert(Comment comment);
        Comment CommentGetById(int id);
        List<Comment> GetPublishedCommentById(int id);
    }
}
