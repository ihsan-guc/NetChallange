using NetChallange.DAL.Abstract;

namespace NetChallange.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(NetChallangeContext context, ICompanyRepository companyRepository,
            IAddressRepository addressRepository, IContactRepository contactRepository)
        {
            Context = context;
            CompanyRepository = companyRepository;
            AddressRepository = addressRepository;
            ContactRepository = contactRepository;
        }
        public NetChallangeContext Context { get; set; }
        public ICompanyRepository CompanyRepository{ get; set; }
        public IContactRepository ContactRepository{ get; set; }
        public IAddressRepository AddressRepository{ get; set; }
        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
