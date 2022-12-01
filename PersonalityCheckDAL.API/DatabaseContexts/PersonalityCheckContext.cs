using Microsoft.EntityFrameworkCore;
using PersonalityCheckDAL.API.Entities;

namespace PersonalityCheckDAL.API.DatabaseContexts
{
    public partial class PersonalityCheckContext : DbContext
    {
        public PersonalityCheckContext()
        {

        }

        public PersonalityCheckContext(DbContextOptions<PersonalityCheckContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
    }
}
