using Avery.LabelManager.DAL.Models;
using Avery.LabelManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avery.LabelManager.DAL.Repositories
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(DbContext context) : base(context)
        {
        }

        private AveryDbContext AppContext => (AveryDbContext)Context;
    }
}