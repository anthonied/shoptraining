using Domain;
using Microsoft.EntityFrameworkCore;

namespace Shop.Data.DomainServices
{
    public interface IProductDomainService
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> InsertAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(Guid id);
    }
    public class ProductDomainService(ShopContext db) : DomainServiceBase<Product>(db), IProductDomainService
    {
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Product> InsertAsync(Product product)
        {
            DbSet.Add(product);
            await Db.SaveChangesAsync();
            return product;
        }

        public async Task<int> UpdateAsync(Product product)
        {
            DbSet.Update(product);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            if (entity != null) DbSet.Remove(entity);
            return await Db.SaveChangesAsync();
        }
    }
}
