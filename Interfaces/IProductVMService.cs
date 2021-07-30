using Microsoft.AspNetCore.Mvc.Rendering;
using SSDeShopOnWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Interfaces
{
    public interface IProductVMService
    {
        ProductIndexVM GetProductsVM(int? typeId);
        IEnumerable<SelectListItem> GetTypes();
    }
}
