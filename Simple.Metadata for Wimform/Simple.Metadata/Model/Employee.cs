using System.ComponentModel;

namespace Simple.Metadata
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [DisplayName("111111")]
        public int Id { get; set; }

        [StringLength(10)]
        public string UserId { get; set; }

        [StringLength(10)]
        public string Password { get; set; }
    }
}