using FirsBlog_Core.DTOs.Posts;
using FirsBlog_Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_Core.Services.Posts
{
    public interface IPostServices
    {
        OperationResult CreatePost(CreatePostDto createPostDto);
        OperationResult EditPost(EditPostDto editPostDto);
        PostFilterDto FilterAndGetPosts(PostFilterProps filterProps);
        PostDto GetPostById(int id);
        bool IsSlugExist(string slug);
    }
}
