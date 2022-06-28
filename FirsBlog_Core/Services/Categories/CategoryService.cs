using FirsBlog_Core.DTOs.Categories;
using FirsBlog_Core.Mappers;
using FirsBlog_Core.Utilities;
using FirsBlog_DataLayer.Context;
using FirsBlog_DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirsBlog_Core.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _Context;
        public CategoryService(BlogContext Blogcontext)
        {
            _Context = Blogcontext;
        }
        public OperationResult CreateCatgory(CreateCategoryDTO CreateDTO)
        {
            if (IsSlugExist(CreateDTO.Slug.ToSlug()))
            {
                return OperationResult.Error("اسلاگ تکراری است");
            }
            var Category = new Category()
            {
                CreationDate = DateTime.Now,
                IsDelete = false,
                MetaTag = CreateDTO.MetaTag,
                Slug = CreateDTO.Slug.ToSlug(),
                Title = CreateDTO.Title,
                MetaDescription = CreateDTO.MetaDescription,
                ParentId = CreateDTO.ParentId
            };
            _Context.Categories.Add(Category);
            _Context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditCategory(EditCategoryDTO EditDTO)
        {
            var Category = _Context.Categories.FirstOrDefault(c => c.Id == EditDTO.Id);

            if (Category == null)
            {
                return OperationResult.NotFound();
            }
            if (EditDTO.Slug.ToSlug() != Category.Slug)
            {
                if (IsSlugExist(EditDTO.Slug))
                    return OperationResult.Error("اسلاگ تکراری است");
            }
            Category.MetaDescription = EditDTO.MetaDescription;
            Category.MetaTag = EditDTO.MetaTag;
            Category.Title = EditDTO.Title;
            Category.Slug = EditDTO.Slug;
            _Context.SaveChanges();
            return OperationResult.Success();
        }

        public List<CategoryDTO> GetAllCategory()
        {
            return _Context.Categories.Select(categ => CategoryMapper.MapToCategoryDTO(categ)).ToList();
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _Context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return null;
            }
            return CategoryMapper.MapToCategoryDTO(category);
        }

        public CategoryDTO GetCAtegoryBySlug(string Slug)
        {
            var category = _Context.Categories.FirstOrDefault(c => c.Slug == Slug);
            if (category == null)
            {
                return null;
            }
            return CategoryMapper.MapToCategoryDTO(category);
        }

        public bool IsSlugExist(string slug)
        {
            var result = _Context.Categories.Any(s => s.Slug == slug.ToSlug());
            return result;
        }
    }
}
