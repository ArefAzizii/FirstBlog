using FirsBlog_Core.Services.Categories;
using FirstBlog_Web_Ui.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;
using FirsBlog_Core.DTOs.Categories;
using FirsBlog_Core.Utilities;

namespace FirstBlog_Web_Ui.Areas.Admin.Controllers
{
    [Area(AreaName)]
    public class CategoryController : Controller
    {
        private const string AreaName = "admin";
        private readonly ICategoryService _category;
        public CategoryController(ICategoryService categoryService)
        {
            _category = categoryService;
        }
        public IActionResult Index()
        {
            return View(_category.GetAllCategory());
        }
        [Route("/admin/category/add/{parentId?}")]
        public IActionResult AddCategory(int? parentId)
        {
            return View();
        }
        [HttpPost("/admin/category/add/{parentId?}")]
        public IActionResult AddCategory(int? parentId, CreatCategoryViewModel categoryViewModel)
        {
            categoryViewModel.ParentId = parentId;
            var result = _category.CreateCatgory(new CreateCategoryDTO()
            {
                Title = categoryViewModel.Title,
                MetaDescription = categoryViewModel.MetaDescription,
                MetaTag = categoryViewModel.MetaTag,
                Slug = categoryViewModel.Slug.ToSlug(),
                ParentId = categoryViewModel.ParentId
            });
            return RedirectToAction("Index");
        }

        public IActionResult Editcategory(int id)
        {
            var category = _category.GetCategoryById(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            var model = new EditCategoryViewModel()
            {
                MetaDescription = category.MetaDescription,
                MetaTag = category.MetaTag,
                Slug = category.Slug.ToSlug(),
                Title = category.Title
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editcategory(int id, EditCategoryViewModel editCategoryView)
        {
            var result = _category.EditCategory(new EditCategoryDTO()
            {
                MetaDescription = editCategoryView.MetaDescription,
                MetaTag = editCategoryView.MetaTag,
                Slug = editCategoryView.Slug.ToSlug(),
                Title = editCategoryView.Title,
                Id = id
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError("Slug", result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
