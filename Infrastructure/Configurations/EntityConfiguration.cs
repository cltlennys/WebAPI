
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.EntityName)
                            .IsRequired();




            entity
                .HasOne(x => x.Customer)
                .WithMany(x => x.Entities)
                .HasForeignKey(x => x.CustomerId);


        }
    }
}
