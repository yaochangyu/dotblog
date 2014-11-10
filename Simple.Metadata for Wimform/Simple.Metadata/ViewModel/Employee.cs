using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Metadata
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
        internal sealed class EmployeeMetadata
        {
            [DisplayName("流水號")]
            public int Id { get; set; }

            [DisplayName("使用者帳號")]
            public string UserId { get; set; }

            [Browsable(false)]
            public string Password { get; set; }
        }
    }
}