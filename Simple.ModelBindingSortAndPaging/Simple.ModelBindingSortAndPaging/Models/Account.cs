using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Simple.ModelBindingSortAndPaging.Models
{
    [Table("Account")]
    public class Account
    {
        public Account()
        {
            if (this.AccountLogs == null)
            {
                this.AccountLogs = new HashSet<AccountLog>();
            }
        }

        [Key]
        [Required]
        [StringLength(100)]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public int Age { get; set; }
        public string Phone { get; set; }
        public string NickName { get; set; }
        public ICollection<AccountLog> AccountLogs { get; set; }
    }
}