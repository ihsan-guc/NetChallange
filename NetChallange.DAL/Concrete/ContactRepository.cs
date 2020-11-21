using NetChallange.DAL.Abstract;
using NetChallange.Data.Domain.Entities;

namespace NetChallange.DAL.Concrete
{
    public interface IContactRepository : IEfRepository<Contact>
    {

    }
    public class ContactRepository: EfRepository<Contact>, IContactRepository
    {
        public ContactRepository(NetChallangeContext context):base(context)
        {

        }
    }
}
