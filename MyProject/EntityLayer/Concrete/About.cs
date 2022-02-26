using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
       [AllowHtml]
        public string WhoAreWeText { get; set; }
        [AllowHtml]
        public string WhatDoWeDo { get; set; }
        [AllowHtml]
        public string AboutUsInFooter { get; set; }

        public string AboutImage1 { get; set; }
       
        public string AboutImage2 { get; set; }
    }
}
