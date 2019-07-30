using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using WebTestsCore.Pages.SecurePay;

namespace WebTestsCore.Steps
{
    [Binding]
    public class SecurePayHomeSteps: BaseStep
    {
        [When(@"Navigate to ""(.*)"" page in the SecurePay website")]
        public void NavigateSecurePayWebsite(string navigateMenuItem)
        {
            CurrentPage = CurrentPage.As<SecurePayHomePage>().NavigateSecurePay(navigateMenuItem);
            Assert.IsNotNull(CurrentPage, "Unable to click on the link " + navigateMenuItem + " in the Secure Pay menu items");
        }
    }
}
