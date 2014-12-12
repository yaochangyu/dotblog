namespace Simple.AutoMapViewModel.DAL.ViewModel
{
    public class AccountTwViewModel
    {
        [ObjectMapping("UserId")]
        public string 帳號 { get; set; }

        [ObjectMapping("Password")]
        public string 密碼 { get; set; }
    }
}