using human_managerment_backend.Entities;
using HumanManagermentBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace HumanManagermentBackend.Database
{
    public class HumanManagerContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<ShiftEntity> Shifts { get; set; }
        public DbSet<WorkingTimeEntity> WorkingTimes { get; set; }
        public DbSet<WorkingTimeDetailEntity> WorkingTimeDetails { get; set; }
        public DbSet<TimeSlotEntity> TimeSlots { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=12345;database=HumanManagerment");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkingTimeDetailEntity>().HasKey(wtd => new { wtd.WorkingTimeId, wtd.TimeSlotId });

            modelBuilder.Entity<WorkingTimeDetailEntity>()
                .HasOne(wtd => wtd.WorkingTime)
                .WithMany(wt => wt.WorkingTimeDetails)
                .HasForeignKey(wtd => wtd.WorkingTimeId);

            modelBuilder.Entity<WorkingTimeDetailEntity>()
                .HasOne(wtd => wtd.TimeSlot)
                .WithMany(ts => ts.WorkingTimeDetails)
                .HasForeignKey(wtd => wtd.TimeSlotId);
        }
    }
}
