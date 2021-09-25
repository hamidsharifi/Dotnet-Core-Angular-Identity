using Avery.LabelManager.DAL.Repositories;
using Avery.LabelManager.DAL.Repositories.Interfaces;

namespace Avery.LabelManager.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AveryDbContext _context;

        ICustomerRepository _customers;
        IProductRepository _products;
        IOrdersRepository _orders;
        IReportRepository _reports;


        public UnitOfWork(AveryDbContext context)
        {
            _context = context;
        }



        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }



        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }

        public IReportRepository Reports
        {
            get
            {
                if (_reports == null)
                {
                    _reports = new ReportRepository(_context);
                }

                return _reports;
            }
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
