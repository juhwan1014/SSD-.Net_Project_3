using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SSDeShopOnWeb.Pages
{
    [Authorize]
    public class checkoutModel : PageModel
    {
        public void OnGet()
        {
        }
     //   public IActionResult OnPost()
       // {
         //   return RedirectToPage();
       // }
    }
}
