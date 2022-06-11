namespace GaoXiao_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LendingHistory")]
    public partial class LendingHistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string 房號 { get; set; }

        [StringLength(50)]
        public string 租借人 { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime 開始時間 { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime 結束時間 { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 人數 { get; set; }
    }
}
