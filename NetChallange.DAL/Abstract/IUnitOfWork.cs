using NetChallange.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetChallange.DAL.Abstract
{
    public interface IUnitOfWork
    {
        ICompanyRepository CompanyRepository { get; set; }
        IContactRepository ContactRepository { get; set; }
        IAddressRepository AddressRepository { get; set; }
        void Commit();
    }
}
