using FluentAutomation;

namespace Simple.SeleniumGmailTest
{
    public class GmailLogoutResultPage : PageObject<GmailLogoutResultPage>
    {
        public GmailLogoutResultPage(FluentTest test)
            : base(test)
        {
        }

        public void VerifyEmail(string email)
        {
            I.Assert.Text(email).In("#reauthEmail");
        }
    }
}