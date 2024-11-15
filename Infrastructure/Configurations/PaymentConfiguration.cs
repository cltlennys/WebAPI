

using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {

        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Amount)
                .IsRequired();

            entity.Property(x => x.AvaibleCredit)
                .IsRequired();

            entity.Property(x => x.PaymentMethod)
                .IsRequired();

            entity.Property(x => x.Date)
                .IsRequired();



            entity
                .HasOne(x => x.Card)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.CardId);


        }

    }
}
