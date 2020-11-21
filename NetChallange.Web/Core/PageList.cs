using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetChallange.Web.Core
{
    public interface IPagedList<T> : IList<T> where T : class
    {
        int pagenumber { get; }
        int pagesize { get; }
    }
    public class PageList<T> : List<T>, IPagedList<T> where T : class
    {
        public int pagenumber{ get;}

        public int pagesize { get; }
    }
}
