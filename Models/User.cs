namespace GaoXiao_Final.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            LendingStatus = new HashSet<LendingStatu>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Uid { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(64)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telephone { get; set; }

        [StringLength(20)]
        public string Account { get; set; }

        [StringLength(64)]
        public string Password { get; set; }

        public int? Sid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LendingStatu> LendingStatus { get; set; }

        public virtual StudentDetail StudentDetail { get; set; }
    }
}
