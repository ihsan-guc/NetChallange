using NetChallange.DAL.Abstract;
using NetChallange.Data.Domain.Entities;

namespace NetChallange.DAL.Concrete
{
    public interface ICompanyRepository : IEfRepository<Company>
    {

    }
    public class CompanyRepository: EfRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(NetChallangeContext context):base(context)
        {

        }
    }
}
