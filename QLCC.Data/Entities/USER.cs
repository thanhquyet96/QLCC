using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLCC.Data.Entities
{
    [Table("USER")]
    public class USER
    {
        [Key]
        public int ID { get; set; }
        [Column("nvarchar(50)")]
        public string USER_NAME { get; set; }
        [JsonIgnore]
        public string PASSWORD { get; set; }
        public string FULL_NAME { get; set; }

        public string PHONE_NUMBER { get; set; }
        public string ADDRESS { get; set; }
        public DateTime? BIRTH_DAY { get; set; }
        public double? COEFFICIENTS_SALARY { get; set; }
        /// <summary>
        /// Ngày nghỉ phép
        /// </summary>
        public int? VACATION_DAY { get; set; }
        /// <summary>
        /// Số ngày đã nghỉ
        /// </summary>
        public int? NUMBER_OF_DAYS { get; set; }
        public decimal? SALARY { get; set; }
        public virtual ICollection<USER_ROLE> USER_ROLES { get; set; }
        [InverseProperty("APPROVE_USER")]
        public virtual ICollection<LEAVE> LEAVES { get; set; }
        [InverseProperty("USER")]
        public virtual ICollection<TIME_KEEP> TIME_KEEPS { get; set; }
    }
}
