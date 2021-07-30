using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; private set; }
        public string Description { get; private set; }
        [Column(TypeName = "money")]
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int ProductTypeId { get; private set; }
        //navigation properties
        public virtual ICollection<CartProduct> CartProducts { get; set; }
        public virtual ProductType ProductType { get; set; }
        public Product(
            int productTypeId,
            string description,
            string name,
            decimal price,
            string pictureUri)
        {
            ProductTypeId = productTypeId;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }
    }
}
