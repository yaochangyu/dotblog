
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace Simple.ModelBindingSortAndPaging.Models
{
    public class AccountViewModel
    {
        public string 帳號 { get; set; }

        [Range(18, int.MaxValue, ErrorMessage = "你未成年")]
        [Display(Name = "歲月~不嬈人阿")]
        public int 年齡 { get; set; }
        public string 電話 { get; set; }

        public string 外號 { get; set; }
        public string 密碼 { get; set; }


    }
}