namespace DAL.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Member")]
    public partial class Member
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Account { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }
    }
}
