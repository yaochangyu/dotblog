namespace Simple.Utility
{
    public class Security
    {
        public bool IsVerify(string userId, string password)
        {
            return userId == "yao" && password == "1234";
        }

        public bool IsVerify(Account account)
        {
            return account.UserId == "yao" && account.Password == "1234";
        }
    }
}