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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void CommentDelete(Comment comment)
        {
            _commentDal.Update(comment);
        }

        public Comment CommentGetById(int id)
        {
           return _commentDal.Get(x => x.CommentID == id);
        }

        public void CommentInsert(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public List<Comment> CommentList()
        {
            return _commentDal.List();
        }

        public List<Comment> CommentListByBlogId(int id)
        {
            return _commentDal.ListGetById(x => x.BlogID == id);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentDal.Update(comment);
        }
        public List<Comment> GetCommentByStatus(bool status)
        {
            return _commentDal.ListGetById(x => x.CommentStatus == status);
        }
        public List<Comment> GetPublishedCommentById(int id)
        {
            return _commentDal.ListGetById(x => x.BlogID==id && x.CommentStatus==true);
        }
    }
}
