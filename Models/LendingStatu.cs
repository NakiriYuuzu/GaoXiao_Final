namespace GaoXiao_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LendingStatu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LendingID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(10)]
        public string DiscussionRoom { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int NumberOfPeople { get; set; }

        public int? PersonInCharge { get; set; }

        public virtual DiscussionRoomStatu DiscussionRoomStatu { get; set; }

        public virtual Librarian Librarian { get; set; }

        public virtual User User { get; set; }
    }
}
