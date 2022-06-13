using Microsoft.EntityFrameworkCore;
using Advertisment.DAL.Enteties;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Advertisment.DAL.EntetiesConfigurations;

internal class AdvertismentConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.HasKey(keyExpression => keyExpression.Id);
        //builder.HasOne(a => a.User).WithMany(u => u.Advertisments).HasForeignKey(x => x.UserId);
    }
}
