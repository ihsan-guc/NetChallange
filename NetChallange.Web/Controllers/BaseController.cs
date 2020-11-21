using Microsoft.AspNetCore.Mvc;
using NetChallange.DAL.Abstract;

namespace NetChallange.Web.Controllers
{
    public class BaseController : Controller
    {
        private IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                    unitOfWork = (IUnitOfWork)HttpContext.RequestServices.GetService(typeof(IUnitOfWork));
                return unitOfWork;
            }
        }

    }
}
