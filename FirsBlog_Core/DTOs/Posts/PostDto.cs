using FirsBlog_Core.DTOs.Categories;
using System;

namespace FirsBlog_Core.DTOs.Posts
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public CategoryDTO Category { get; set; }
        public DateTime CreationDate { get; set; }
        public int Visit { get; set; }
        public bool  IsDelete { get; set; }
    }

}
