using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_DataLayer.Entities
{
    public class Post : BaseEntity

    {

        public int UserId { get; set; }
        public int? SecCategoryId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImageName { get; set; }
        public int Visit { get; set; }


        #region Relations
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("SecCategoryId")]
        public Category SecondCategory { get; set; }
        public ICollection<PostComment> PostComments { get; set; }
        #endregion

    }
}
