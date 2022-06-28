namespace FirsBlog_Core.DTOs.Posts
{
    public class EditPostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
    }

}
