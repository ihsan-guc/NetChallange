using NetChallange.DAL.Abstract;
using NetChallange.Data.Domain.Entities;

namespace NetChallange.DAL.Concrete
{
    public interface IAddressRepository : IEfRepository<Address>
    {

    }
    public class AddressRepository: EfRepository<Address>, IAddressRepository
    {
        public AddressRepository(NetChallangeContext context):base(context)
        {

        }
    }
}
