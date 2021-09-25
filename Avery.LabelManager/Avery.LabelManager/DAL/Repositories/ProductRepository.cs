// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Avery.LabelManager.DAL.Models;
using Avery.LabelManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avery.LabelManager.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        { }




        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
