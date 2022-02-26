using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
      
        public string AuthorName { get; set; }
        
        public string AuthorImage { get; set; }
       
        public string AuthorAbout { get; set; }
        public string AuthorTitle { get; set; }
        public string AboutShort { get; set; }
        public string AuthorMail { get; set; }
        public string AuthorPassword { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Lütfen başında 0 olmadan geçerli bir telefon numarası giriniz.")]
        public string AuthorPhoneNumber{ get; set; }
        public  ICollection<Blog> Blogs { get; set; }
    }
}
