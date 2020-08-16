using human_managerment_backend.Entities;
using HumanManagermentBackend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HumanManagermentBackend.Database
{
    public class HumanManagerContext : DbContext
    {
        public DbSet<ConfigureEntity> Configures { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<JobEntity> Jobs { get; set; }
        public DbSet<JobHistoryEntity> JobHistorys { get; set; }
        public DbSet<JobHistoryDetailEntity> JobHistoryDetails { get; set; }
        public DbSet<SalaryHistoryEntity> SalaryHistories { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<JobLevelEntity> JobLevels { get; set; }
        public DbSet<RewardPunishEntity> RewardPunishes { get; set; }
        public DbSet<InsurranceEntity> Insurrances { get; set; }
        public DbSet<ShiftEntity> Shifts { get; set; }
        public DbSet<WorkingTimeEntity> WorkingTimes { get; set; }
        public DbSet<WorkingTimeDetailEntity> WorkingTimeDetails { get; set; }
        public DbSet<TimeSlotEntity> TimeSlots { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<WardEntity> Wards { get; set; }
        public DbSet<DistrictEntity> Districts { get; set; }
        public DbSet<ProvinceEntity> Provinces { get; set; }
        public DbSet<DegreeEntity> Degrees { get; set; }
        public DbSet<IndentificationEntity> Indentifications { get; set; }
        public DbSet<TimeKeepingEntity> Timekeepings { get; set; }

        public DbSet<TimeKeepingDetailEntity> TimeKeepingDetails { get; set; }

        public DbSet<CandidateEntity> Candidates { get; set; }

        public DbSet<NoteEntity> Notes { get; set; }
        public DbSet<ScheduleEntity> Schedules { get; set; }
        public DbSet<TaxEntity> Taxs { get; set; }

        public IEnumerable<object> TimeKeepings { get; internal set; }

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

            modelBuilder.Entity<AddressEntity>()
                .HasOne(w => w.Ward)
                .WithMany(a => a.Addresses)
                .HasForeignKey(wk => wk.Ward_Id);

            modelBuilder.Entity<WardEntity>()
                .HasOne(d => d.District)
                .WithMany(w => w.Wards)
                .HasForeignKey(dk => dk.District_Id);

            modelBuilder.Entity<DistrictEntity>()
                .HasOne(p => p.Province)
                .WithMany(d => d.Districts)
                .HasForeignKey(pk => pk.Province_Id);

            modelBuilder.Entity<JobHistoryEntity>().HasKey(jh => new { jh.JobId, jh.DepartmentId });

            modelBuilder.Entity<JobHistoryEntity>()
                .HasOne(jh => jh.Job)
                .WithMany(j => j.JobHistorys)
                .HasForeignKey(jh => jh.JobId);

            modelBuilder.Entity<JobHistoryEntity>()
                .HasOne(jh => jh.Department)
                .WithMany(d => d.JobHistorys)
                .HasForeignKey(jh => jh.DepartmentId);

            modelBuilder.Entity<NoteEntity>()
                .HasOne(c => c.Candidate)
                .WithOne(n => n.Note)
                .HasForeignKey<CandidateEntity>(ni => ni.Note_Id);

            modelBuilder.Entity<ScheduleEntity>()
                .HasOne(c => c.Candidate)
                .WithMany(s => s.Schedules)
                .HasForeignKey(ci => ci.CanId);
                
            modelBuilder.Entity<JobEntity>()
                .HasOne(j => j.JobLevel)
                .WithOne(jlv => jlv.Job)
                .HasForeignKey<JobLevelEntity>(jlv => jlv.JobId);

        }
    }
}
