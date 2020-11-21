using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetChallange.Data.Domain.Entities;

namespace NetChallange.DAL.Mapping
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasOne(navigationExpression: m => m.Company)
                .WithOne(navigationExpression: g => g.Contact)
                .HasForeignKey<Company>(s => s.ContactId);

            builder.HasOne(navigationExpression: m => m.Address)
                .WithOne(navigationExpression: g => g.Contact)
                .HasForeignKey<Address>(s => s.ContactId);
        }
    }
}
