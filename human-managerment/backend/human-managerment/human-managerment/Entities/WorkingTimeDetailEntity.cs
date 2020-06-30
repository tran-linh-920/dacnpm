using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace human_managerment_backend.Entities
{
    [Table("WorkingTimeDetails")]
    public class WorkingTimeDetailEntity
    {
        public long WorkingTimeId { get; set; }
        public WorkingTimeEntity WorkingTime { get; set; }

        public long TimeSlotId { get; set; }
        public TimeSlotEntity TimeSlot { get; set; }

      
    }
}