using FluentAutomation;

namespace Simple.SeleniumGmailTest
{
    public class GmailLogoutPage : FluentAutomation.PageObject<GmailLoginPage>
    {
        public GmailLogoutPage(FluentTest test)
            : base(test)
        {
        }

        public void Submit()
        {
            //logout
            I.Click("span.gb_6.gbii");
            I.Click("#gb_71");
        }
    }
}