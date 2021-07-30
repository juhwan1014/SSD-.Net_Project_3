using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SSDeShopOnWeb.Data;
using SSDeShopOnWeb.Interfaces;
using SSDeShopOnWeb.Models;
using SSDeShopOnWeb.ViewModels;

namespace SSDeShopOnWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductVMService _productVMService;

        public IndexModel(IProductVMService productVMService)
        {
            _productVMService = productVMService;
        }

        public ProductIndexVM ProductIndex = new ProductIndexVM();

        public async Task OnGet(ProductIndexVM productIndex)
        {
            ProductIndex = _productVMService.GetProductsVM(productIndex.TypesFilterApplied);      
        }
    }
}
