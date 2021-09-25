




using System.Collections.Generic;
using Avery.LabelManager.DAL.Models;

namespace Avery.LabelManager.DAL.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetTopActiveCustomers(int count);
        IEnumerable<Customer> GetAllCustomersData();
    }
}
