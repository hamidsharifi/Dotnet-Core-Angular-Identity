// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using Avery.LabelManager.DAL.Core;
using DAL;
using DAL.Core;
using Microsoft.AspNetCore.Http;

namespace Avery.LabelManager.DAL
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(AveryDbContext context, IHttpContextAccessor httpAccessor) : base(context)
        {
            context.CurrentUserId = httpAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
        }
    }
}
