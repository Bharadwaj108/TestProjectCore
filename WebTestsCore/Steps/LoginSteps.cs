using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using WebTestsCore.Pages;

namespace WebTestsCore.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        [Given(@"I have logged as ""(.*)"" using the login credentials")]
        public void LoginToOfficeWorksAccount(string userName)
        {
            CurrentPage = CurrentPage.As<LoginPage>().Login(userName);
            Assert.IsNotNull(CurrentPage);
        }

        [Given(@"I have logged as ""(.*)"" and password ""(.*)""")]
        public void GivenIHaveLoggedAsAndPassword(string userName, string password)
        {
            CurrentPage = CurrentPage.As<LoginPage>().Login(userName,password);
            Assert.IsNotNull(CurrentPage);
        }


    }
}
