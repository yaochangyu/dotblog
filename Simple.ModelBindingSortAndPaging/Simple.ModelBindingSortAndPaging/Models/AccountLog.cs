﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Simple.ModelBindingSortAndPaging.Models
{
    [Table("AccountLog")]
    public class AccountLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime LastLoginTime { get; set; }

        public virtual Account CurrentAccount { get; set; }
    }
}