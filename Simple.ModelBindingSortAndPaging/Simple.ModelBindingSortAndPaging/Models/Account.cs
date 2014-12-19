using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Display(Name = "歲月~")]
        public int Age { get; set; }

        public string Phone { get; set; }

        public string NickName { get; set; }

        public ICollection<AccountLog> AccountLogs { get; set; }
    }
}