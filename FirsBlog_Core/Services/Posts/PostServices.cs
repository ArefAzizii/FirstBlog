using FirsBlog_Core.DTOs.Posts;
using FirsBlog_Core.Utilities;
using FirsBlog_DataLayer.Context;
using System;
using System.Linq;
using FirsBlog_DataLayer.Entities;

namespace FirsBlog_Core.Services.Posts
{
    public class PostServices : IPostServices
    {
        private readonly BlogContext _context;
        public PostServices(BlogContext context)
        {
            _context = context;
        }

        public PostFilterDto FilterAndGetPosts(PostFilterProps filterProps)
        {
            var result = _context.Posts.OrderByDescending(p => p.CreationDate).AsQueryable();
            if (string.IsNullOrWhiteSpace(filterProps.CategorySlug))
            {
                result = result.Where(r=> r.Category.Slug == filterProps.CategorySlug);
            }
            if (string.IsNullOrWhiteSpace(filterProps.TitleForSearch))
            {
                result = result.Where(p => p.Title.Contains(filterProps.TitleForSearch));
            }
            var skip = (filterProps.PageId - 1) * filterProps.Take;
            var PageCount = result.Count() / filterProps.Take;

            return new PostFilterDto()
            {
                Posts = result.Skip(skip).Take(filterProps.Take).Select(p => Mappers.PostMapper.MapPostToDto(p)).ToList(),
                PageCount = PageCount,
                FilterProps = filterProps
            };
        }

        OperationResult IPostServices.CreatePost(CreatePostDto createPostDto)
        {
            var newPost = Mappers.PostMapper.MapDtoToPost(createPostDto);
            _context.Posts.Add(newPost);
            _context.SaveChanges(); 
            return OperationResult.Success();
            //if (newPost!=null)
            //{
            //    OperationResult.Success();
            //}
            //return OperationResult.Error();
        }

        OperationResult IPostServices.EditPost(EditPostDto editPostDto)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == editPostDto.PostId);
            if (post == null)
            {
                OperationResult.NotFound();
            }
            Mappers.PostMapper.MapeditDtoToPost(editPostDto, post);
            _context.Posts.Update(post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        PostDto IPostServices.GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            var postDto = Mappers.PostMapper.MapPostToDto(post);
            return postDto;
        }

        bool IPostServices.IsSlugExist(string slug)
        {
            return _context.Posts.Any(p => p.Slug == slug.ToSlug());
        }
    }
}
