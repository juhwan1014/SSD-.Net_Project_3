using Microsoft.AspNetCore.Mvc.Rendering;
using SSDeShopOnWeb.Interfaces;
using SSDeShopOnWeb.Models;
using SSDeShopOnWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Services
{
    public class ProductVMService : IProductVMService
    {
        private readonly IBaseRepository<Product> _productRepo;
        private readonly IBaseRepository<ProductType> _typeRepo;

        public ProductVMService(IBaseRepository<Product> productRepo, IBaseRepository<ProductType> typeRepo)
        {
            _productRepo = productRepo;
            _typeRepo = typeRepo;
        }
        public ProductIndexVM GetProductsVM(int? typeId)
        {
            IQueryable<Product> products = _productRepo.GetAll();
            if (typeId != null)
                products = products.Where(p=>p.ProductTypeId == typeId);

            var vm = new ProductIndexVM()
            {
                Products = products.Select(p => new ProductVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    PictureUri = p.PictureUri,
                    Quantity = 1
                }).ToList(),
                Types = GetTypes().ToList()
            };
            return vm;
        }
        public IEnumerable<SelectListItem> GetTypes()
        {
            var types = _typeRepo.GetAll().Select(t => new SelectListItem()
            {
                Value = t.Id.ToString(),
                Text = t.Type
            }).OrderBy(t => t.Text).ToList();

            var allItem = new SelectListItem() { Value = null, Text = "All", Selected = true };
            types.Insert(0, allItem);

            return types;
        }
    }
}
