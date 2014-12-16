using FluentAutomation;

namespace Simple.SeleniumGmailTest
{
    public class GmailLoginPage : FluentAutomation.PageObject<GmailLoginPage>
    {
        public GmailLoginPage(FluentTest test, string url)
            : base(test)
        {
            this.Url = url;
        }

        public void Submit(string userId, string password)
        {
            I.Open(this.Url)
               .Enter(userId).In("#Email")
               .Enter(password).In("#Passwd")
               .Click("#signIn");
        }
    }
}