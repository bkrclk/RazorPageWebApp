using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageWebApp.Models;
using RazorPageWebApp.Models.Validations;

namespace RazorPageWebApp
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public UserModel UserModel { set; get; }
         
        public IActionResult OnPostSignin()
        {
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(UserModel);
            if (result.IsValid)
            {

                if (UserModel.UserName.Equals("bekir") && UserModel.Password.Equals("12346578"))
                {
                    HttpContext.Session.SetString("username", UserModel.UserName);

                    var username = HttpContext.Session.GetString("username");

                    return RedirectToPage("Index");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return Page();

        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("Index");
        }

        public IActionResult OnGetSignin()
        {
            return RedirectToPage("SignIn");
        }
    }
}