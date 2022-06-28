using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_Core.DTOs.Posts
{
   public class PostFilterDto
    {
        public int PageCount { get; set; }
        public PostFilterProps FilterProps { get; set; }
        public List<PostDto> Posts { get; set; }
    }
    public class PostFilterProps 
    {
        public int PageId { get; set; }
        public int Take { get; set; }
        public string TitleForSearch { get; set; }
        public string CategorySlug { get; set; }
    }
}
