




using Avery.LabelManager.DAL.Models;
using Avery.LabelManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avery.LabelManager.DAL.Repositories
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(DbContext context) : base(context)
        { }




        private AveryDbContext _appContext => (AveryDbContext)Context;
    }
}
