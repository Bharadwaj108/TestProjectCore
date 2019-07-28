using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using WebTestsCore.Pages;

namespace WebTestsCore.Steps
{
    [Binding]
    public class HomeSteps : BaseStep
    {
        [Given(@"I navigate to the Officeworks website")]
        public void GivenINavigateToTheOfficeworksWebsite()
        {
            NaviateSite();
            CurrentPage = GetInstance<LoginPage>();
            Assert.IsNotNull(CurrentPage);
        }

        [Given(@"I have navigated to ""(.*)"" section under the ""(.*)"" main menu item")]
        public void NavigateOfficeworksMainMenu(string subMenuItem, string mainMenuItem)
        {
            CurrentPage = CurrentPage.As<HomePage>().NavigateMainMenu(mainMenuItem);
            Assert.IsNotNull(CurrentPage);
            CurrentPage = CurrentPage.As<ItemsPage>().SelectItem(subMenuItem);
            Assert.IsNotNull(CurrentPage);
        }

    }

}
