using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDeShopOnWeb.Data;
using SSDeShopOnWeb.Models;
using SSDeShopOnWeb.ViewModels;

namespace SSDeShopOnWeb.Pages.ShoppingCart
{
    public class IndexModel : PageModel
    {
        private readonly StoreDbContext _db;
        public IndexModel(StoreDbContext db)
        {
            _db = db;
        }

        public Cart Cart { get; set; }

        public void OnGet()
        {
            int? cartId = HttpContext.Session.GetInt32("cartId");
            if(cartId != null)
                Cart = _db.Carts
                    .Include(c => c.CartProducts)
                    .ThenInclude(cp => cp.Product)
                    .Where(c => c.Id == (int)HttpContext.Session.GetInt32("cartId"))
                    .FirstOrDefault();
        }
        public IActionResult OnPost(ProductVM cartProduct)
        {
            if (cartProduct?.Id == null)
            {
                return RedirectToPage("/Index");
            }
            //(need to validate against user or session)
            int? cartId = HttpContext.Session.GetInt32("cartId");
            //add new cart if none exists
            if (cartId == null)
            {
                Cart = new Cart(null);
                _db.Carts.Add(Cart);
                _db.SaveChanges();
                cartId = Cart.Id;
            }
            //Now we know that we have a cartId from session or create
            HttpContext.Session.SetInt32("cartId", (int)cartId);

            //need to handle cartproduct 
            CartProduct cp;
            //check if product is already in the cart
            cp = _db.CartProducts
                    .Where(cp => cp.CartId == cartId && cp.ProductId == cartProduct.Id)
                    .FirstOrDefault();
            if (cp == null) // product not in this cart yet
            {
                cp = new CartProduct((int)cartId, cartProduct.Id, cartProduct.Price, cartProduct.Quantity);
                _db.CartProducts.Add(cp);
            }
            else // product is already in cart
            {
                //might want to validate for price changes in the future ;)
                cp.AddQuantity(cartProduct.Quantity);
            }
            _db.SaveChanges();
            return RedirectToPage();
        }      
    }
}
