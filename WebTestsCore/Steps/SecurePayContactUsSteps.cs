using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using WebTestsCore.Context;
using WebTestsCore.Pages.SecurePay;

namespace WebTestsCore.Steps
{
    [Binding]
    public class SecurePayContactUsSteps:BaseStep
    {
        ContactUs contactUs = null;
        [Then(@"Contact Us Page is loaded")]
        public void ThenContactUsPageIsLoaded()
        {
            Assert.IsTrue(CurrentPage.As<SecurePayContactUsPage>().ISContactUsPageLoaded());
        }

        [Given(@"I generate random Contact test data")]
        public void GivenIGenerateRandomContactTestData()
        {
            contactUs = CurrentPage.As<SecurePayContactUsPage>().PrepareRandomTestData();
            Assert.IsNotNull(contactUs,"Failed to generate random test data");
        }

        [Given(@"Fill the Contact Details in the Contact Us form")]
        public void GivenFillTheContactDetailsInTheContactUsForm()
        {
            Assert.IsTrue(CurrentPage.As<SecurePayContactUsPage>().FillContactDetails(contactUs));
        }



    }
}
