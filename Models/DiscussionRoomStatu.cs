namespace GaoXiao_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DiscussionRoomStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiscussionRoomStatu()
        {
            LendingStatus = new HashSet<LendingStatu>();
        }

        [Key]
        [StringLength(10)]
        public string RoomNumber { get; set; }

        public int Floors { get; set; }

        [StringLength(20)]
        public string RoomType { get; set; }

        [StringLength(20)]
        public string RoomAccess { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LendingStatu> LendingStatus { get; set; }
    }
}
