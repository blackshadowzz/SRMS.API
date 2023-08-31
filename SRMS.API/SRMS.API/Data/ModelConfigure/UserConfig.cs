using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRMS.Shared.Models;

namespace SRMS.API.Data.ModelConfigure
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            //builder.HasData(new User
            //{
            //    UserId = 1,
            //    FullName = "Admin",
            //    UserType= "Admin",
            //    Image ="",
            //    Username="admin",
            //});
        }
    }
}
