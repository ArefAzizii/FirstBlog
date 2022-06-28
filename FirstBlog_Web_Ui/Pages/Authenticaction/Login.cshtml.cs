using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using FirsBlog_Core.DTOs.Users;
using FirsBlog_Core.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstBlog_Web_Ui.Pages.Authenticaction
{
    [ValidateAntiForgeryToken]
    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;    
        }
        #region Properties
        [Required(ErrorMessage = "Enter the username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter the password")]
        [MinLength(5, ErrorMessage = "Password must bigger than 5 charactres")]
        public string Password { get; set; }
        #endregion
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var user = _userService.IsUserExisted(new UserLoginDTO ()
            {  
                Password=Password,
                Username=Username
            });
            if (user==null)
            {
                ModelState.AddModelError("Username", "User with this information NotFound");
                return Page();
            }
            List<Claim> claims = new() { 
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FullName)
            };
                
            var Identity= new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var ClaimPrincipal = new ClaimsPrincipal(Identity);
            var Properties = new AuthenticationProperties() { 
             IsPersistent = true
            };
            HttpContext.SignInAsync(ClaimPrincipal , Properties);
            return RedirectToPage("../Index");
        }
    }
}
