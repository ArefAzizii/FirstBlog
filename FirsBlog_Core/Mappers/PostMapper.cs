using FirsBlog_Core.DTOs.Posts;
using FirsBlog_Core.Utilities;
using FirsBlog_DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_Core.Mappers
{
    public class PostMapper
    {
        public static Post MapDtoToPost(CreatePostDto dto)
        {
            var post = new Post
            {
                Description = dto.Description,
                CategoryId = dto.CategoryId,
                Title = dto.Title,
                Slug = dto.Slug,
                UserId = dto.UserId,
                IsDelete = false,
                Visit = 0
            };
            return post;
        }
        public static PostDto MapPostToDto(Post post)
        {
            var Postdto = new PostDto
            {
                Description = post.Description,
                CategoryId = post.CategoryId,
                Title = post.Title,
                Slug = post.Slug,
                UserId = post.UserId,
                IsDelete = false,
                Visit = 0,
                CreationDate = post.CreationDate,
                Category = CategoryMapper.MapToCategoryDTO(post.Category),
                //ImageName=post.Imagename

            };
            return Postdto;
        }
        public static Post MapeditDtoToPost(EditPostDto editDto, Post post)
        {
            post.CategoryId = editDto.CategoryId;
            post.Description = editDto.Description;
            post.Title = editDto.Title;
            post.Slug = editDto.Slug.ToSlug();
            return post;
        }
    }
}
