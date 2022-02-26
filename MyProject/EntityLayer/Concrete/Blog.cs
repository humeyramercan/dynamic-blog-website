using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
       
        public string BlogTitle { get; set; }
  
        public string BlogCoverImage { get; set; }
        public DateTime BlogDate { get; set; }
        [AllowHtml]
        public string BlogContent { get; set; }

        public bool BlogStatus { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int BlogRating { get; set; }

        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
