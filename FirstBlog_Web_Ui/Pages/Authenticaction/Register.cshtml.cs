using System;
using System.Collections.Generic;
using FirsBlog_Core.DTOs.Users;
using FirsBlog_Core.Utilities;
using FirsBlog_Core.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace FirstBlog_Web_Ui.Pages.Authenticaction
{ 
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class RegisterModel : PageModel
    {
        #region Properties
        [Required(ErrorMessage ="Enter the {0}")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Enter the {0}")]
        public string FullName { get; set; }
      
        [Required(ErrorMessage ="Enter the {0}")]
        [MinLength(6,ErrorMessage ="{0} can not be minner than six items")]
        [MaxLength(30)]
        public string Password { get; set; }
        #endregion



        private readonly IUserService _userService;
        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _userService.RegisterUser(new UserRegisterDTO { 
            UserName=UserName,
            Password=Password,
            FullName=FullName
            });
            if (result.Status==OperationResultStatus.Error)
            {
                ModelState.AddModelError("Username",result.Message);
                return Page();
            }
            return RedirectToPage("Login");
        }
    }
}
