using SSDeShopOnWeb.Interfaces;
using SSDeShopOnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSDeShopOnWeb.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity
    {
        protected readonly StoreDbContext _db;

        public BaseRepository(StoreDbContext db)
        {
            _db = db;
        }

        public IQueryable<T> GetAll()
        {
            return _db.Set<T>();
        }
    }
}
