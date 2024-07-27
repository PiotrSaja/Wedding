using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wedding.Api.Data.Configuration
{
    public class WeddingConfiguration : IEntityTypeConfiguration<Models.Wedding>
    {
        public void Configure(EntityTypeBuilder<Models.Wedding> builder)
        {
        }
    }
}
