using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HumanManagermentBackend.Entities
{
    [Table("Candidates")]
    public class CandidateEntity
    {
        [Key, Column("can_id", TypeName = "bigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Column("canFirstname", TypeName = "nvarchar(256)"), Required]
        public string Firstname { get; set; }

        [Column("canLastname", TypeName = "nvarchar(256)"), Required]
        public string Lastname { get; set; }

        [Column("canBirthDay", TypeName = "date"), Required]
        public DateTime BirthDay { get; set; }

        [Column("canGender", TypeName = "bit"), Required]
        public bool Gender { get; set; }

        [Column("canEmail", TypeName = "varchar(128)"), Required]
        public string Email { get; set; }

        [Column("canPhone", TypeName = "varchar(128)"), Required]
        public string PhoneNumber { get; set; }

        [Column("canImageName", TypeName = "varchar(128)"), Required]
        public string ImageName { get; set; }

        [Column("canEthnic", TypeName = "nvarchar(128)")]
        public string Ethnic { get; set; }

        [Column("canHometown", TypeName = "nvarchar(256)")]
        public string Hometown { get; set; }

        [Column("canIDCard", TypeName = "varchar(128)")]
        public string IDCard { get; set; }

        [Column("canDegree", TypeName = "nvarchar(256)")]
        public string Degree { get; set; }

        [Column("canCareer", TypeName = "nvarchar(256)")]
        public string Career { get; set; }


        [Column("canExperience")]
        public string Experience { get; set; }

        [Column("canLiteracy", TypeName = "nvarchar(256)")]
        public string Literacy { get; set; }

        [Column("canSkill")]
        [MaxLength]
        public string Skill { get; set; }

        [Column("canHobby")]
        [MaxLength]
        public string Hobby { get; set; }

        [Column("canPosition")]
        public string Position { get; set; }

        [Column("canStatus", TypeName = "int")]
        public int Status { get; set; }

        [Column("note_id", TypeName = "bigint")]
        public long Note_Id { get; set; }

        [JsonIgnore]
        public NoteEntity Note { get; set; }

        [JsonIgnore]
        public ICollection<ScheduleEntity> Schedules { get; set; }

    }
}
