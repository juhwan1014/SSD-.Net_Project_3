using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Models
{
    public class ProductType: BaseEntity
    {
        public string Type { get; private set; }

        //navigation properties
        public virtual ICollection<Product> TypeProducts { get; set; }
        public ProductType(string type)
        {
            Type = type;
        }
    }
}
