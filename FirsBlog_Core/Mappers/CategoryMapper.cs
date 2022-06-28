using FirsBlog_Core.DTOs.Categories;
using FirsBlog_DataLayer.Entities;

namespace FirsBlog_Core.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDTO MapToCategoryDTO(Category category)
        {
            var categoryDto = new CategoryDTO()
            {
                MetaDescription = category.MetaDescription,
                CreationDate = category.CreationDate,
                MetaTag = category.MetaTag,
                Slug = category.Slug,
                Title = category.Title,
                Id = category.Id,
                ParentId = category.ParentId
            };
            return categoryDto;
        }
    }
}
