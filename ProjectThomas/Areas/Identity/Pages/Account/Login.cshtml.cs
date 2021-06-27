using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProjectThomas.Models;

namespace ProjectThomas.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly ProjectThomas.Data.ApplicationDbContext _context;

        public LoginModel(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager, ProjectThomas.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        public CarouselImage img1 { get; set; }
        public CarouselImage img2 { get; set; }
        public CarouselImage img3 { get; set; }
        public CarouselImage img4 { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;

            img1 = GetRandomImg();
            img2 = GetRandomImg(img1.CarouselImageId);
            img3 = GetRandomImg(img1.CarouselImageId, img2.CarouselImageId);
            img4 = GetRandomImg(img1.CarouselImageId, img2.CarouselImageId, img3.CarouselImageId);
        }

        private CarouselImage GetRandomImg(int img1 = -1, int img2 = -1, int img3 = -1)
        {
            CarouselImage ci;
            if (img1 == -1)
            {
                ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                return ci;
            }
            else if (img2 == -1)
            {
                do
                {
                    ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                } while (ci.CarouselImageId == img1);
                return ci;
            }
            else if (img3 == -1)
            {
                do
                {
                    ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                } while (ci.CarouselImageId == img1 || ci.CarouselImageId == img2);
                return ci;
            }
            else
            {
                
                do
                {
                    ci = _context.CarouselImage.OrderBy(x => Guid.NewGuid()).First();
                } while (ci.CarouselImageId == img1 || ci.CarouselImageId == img2 || ci.CarouselImageId == img3);
                return ci;

            }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
