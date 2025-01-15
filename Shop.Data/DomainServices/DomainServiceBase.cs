using Microsoft.EntityFrameworkCore;

namespace Shop.Data.DomainServices
{
    public  class DomainServiceBase<TDomain>(ShopContext db) where TDomain : class
    {
        protected readonly ShopContext Db = db;
        protected readonly DbSet<TDomain> DbSet = db.Set<TDomain>();
    }
}
