using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using InvBG.Contacts.Backend.Domain;

namespace InvBG.Contacts.Backend.Infrastructure
{
    public class ContactsDbConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts", ContactsDbContext.DEFAULT_SCHEMA);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .UseIdentityColumn(1, 1);
;

            builder.OwnsOne(e => e.Name, nameBuilder => {
                nameBuilder.Property(r => r.FirstName).HasMaxLength(20).HasColumnName("FirstName");
                nameBuilder.Property(r => r.LastName).HasMaxLength(20).HasColumnName("LastName");
            });

            builder.Property(e => e.DateOfBirth).HasColumnType("date").HasColumnName("DateOfBirth");

            builder.OwnsOne(e => e.Address, addrBuilder =>
            {
                addrBuilder.Property(r => r.Street).HasMaxLength(100).HasColumnName("Street");
                addrBuilder.Property(r => r.ZipCode).HasMaxLength(5).HasColumnName("ZipCode");
                addrBuilder.Property(r => r.City).HasMaxLength(20).HasColumnName("City");
            });

            builder.Property(e => e.PhoneNumber)
                .HasConversion(
                    typed => typed.Value,
                    plain => Phone.Create(plain)
                )
                .HasColumnName("PhoneNumber");

            builder.Property(e => e.IBAN)
                .HasConversion(
                    typed => typed.Value,
                    plain => IBAN.Create(plain))
                .HasColumnName("IBAN");
        }
    }
}
