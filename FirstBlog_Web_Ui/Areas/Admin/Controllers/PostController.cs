using FirsBlog_Core.DTOs.Posts;
using FirsBlog_Core.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstBlog_Web_Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostServices _PostServices;

        public PostController(IPostServices postServices)
        {
            _PostServices = postServices;
        }

        public IActionResult Index(int PageId = 1, string Title = "", string CategorySlug = "")
        {
            var filterParams = new PostFilterProps()
            {
                CategorySlug = CategorySlug,
                TitleForSearch = Title,
                PageId = PageId,
                Take = 20
            };
            var model = _PostServices.FilterAndGetPosts(filterParams);
            return View(model);
        }
        //public IActionResult CreatePost()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreatePost()
        //{
        //    return View();
        //}


    }

}
