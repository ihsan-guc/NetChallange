using NetChallange.Data.Domain.Entities;
using System.Collections.Generic;
using X.PagedList;

namespace NetChallange.Web.Models
{
    public class BaseExportableViewModel<TEntity, TExportViewModel> : BaseHomeViewModel<TEntity>
        where TEntity : BaseGuidEntity
        where TExportViewModel : class
    {
        public IEnumerable<TExportViewModel> ExportList { get; set; }
    }
    public class BaseHomeViewModel<TEntity> where TEntity : BaseGuidEntity
    {
        public IPagedList<TEntity> PagedList { get; set; }
    }
}
