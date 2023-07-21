using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Lastname).HasMaxLength(128);
            builder.Property(x => x.Firstname).HasMaxLength(128);
            builder.Property(x => x.Email).IsUnicode();
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);

        }
    }
}
