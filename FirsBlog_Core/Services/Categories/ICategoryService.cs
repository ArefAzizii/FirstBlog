using FirsBlog_Core.DTOs.Categories;
using FirsBlog_Core.Utilities;
using System.Collections.Generic;

namespace FirsBlog_Core.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCatgory(CreateCategoryDTO CreateDTO);
        OperationResult EditCategory(EditCategoryDTO EditDTO);
        List<CategoryDTO> GetAllCategory();
        CategoryDTO GetCategoryById(int id);
        CategoryDTO GetCAtegoryBySlug(string Slug);
        bool IsSlugExist(string slug);
    }
}
