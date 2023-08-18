using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SRMS.Shared.Models;

namespace SRMS.API.Data.ModelConfigure
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasData(new Level
            {
                LevelId = 1,
                LevelName = "Basic",
                Description = "Level for basic learners",
                IsActive = true
            });
            builder.HasData(new Level
            {
                LevelId = 2,
                LevelName = "Advance",
                Description = "Level for advance learners",
                IsActive = true
            });
            builder.HasData(new Level
            {
                LevelId = 3,
                LevelName = "Full Level",
                Description = "Level for full level learners",
                IsActive = true
            });
        }
    }
}
