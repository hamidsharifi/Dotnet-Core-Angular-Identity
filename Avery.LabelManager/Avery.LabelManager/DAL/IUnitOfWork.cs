using Avery.LabelManager.DAL.Repositories.Interfaces;

namespace Avery.LabelManager.DAL
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        IOrdersRepository Orders { get; }
        IReportRepository Reports { get; }

        int SaveChanges();
    }
}
