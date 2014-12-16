using FluentAutomation;

namespace Simple.SeleniumGmailTest
{
    public class GmailLoninResultPage : PageObject<GmailLoninResultPage>
    {
        private const string s_linkContainer = "a[href='{0}']";

        public GmailLoninResultPage(FluentTest test)
            : base(test)
        {
        }

        public void VerifyRedirectLink(string url)
        {
            I.Assert.Url(url);

        }

        public void VerifyHyperLink(string name, string url)
        {
            I.Assert.Text(name).In(string.Format(s_linkContainer, url));
        }
    }
}