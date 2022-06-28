using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlog_Web_Ui.Areas.Admin.Models.Categories
{
    public class CreatCategoryViewModel
    {
        [Display(Name ="عنوان")]
        [Required(ErrorMessage ="وارد کردن {0} اجباری است")]
        public string Title { get; set; }
        [Display(Name = "slug")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string Slug { get; set; }
        [Display(Name = "MetaTag(با-ازهم جدا کنید) ")]
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }
    }
}
