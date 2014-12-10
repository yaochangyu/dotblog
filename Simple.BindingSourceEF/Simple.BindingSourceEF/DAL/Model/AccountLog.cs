using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple.BindingSourceEF.DAL.Model
{
    [Table("AccountLog")]
    public class AccountLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public Guid Id { get; set; }

        public DateTime LastLoginTime { get; set; }

        [Browsable(false)]
        public virtual Account CurrentAccount { get; set; }
    }
}