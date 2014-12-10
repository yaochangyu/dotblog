using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simple.BindingSourceEF.DAL.Model
{
    [Table("Account")]
    public class Account
    {
        private string _userId;
        private string _password;

        public Account()
        {
            if (this.AccountLogs == null)
            {
                this.AccountLogs = new HashSet<AccountLog>();
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Browsable(false)]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(100)]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                _userId = value;
            }
        }

        [Required]
        [StringLength(100)]
        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }
                _password = value;
            }
        }

        [Browsable(false)]
        public ICollection<AccountLog> AccountLogs { get; set; }
    }
}