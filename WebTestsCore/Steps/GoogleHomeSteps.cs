using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using WebTestsCore.Pages;

namespace WebTestsCore.Steps
{
    [Binding]
    public class GoogleHomeSteps : BaseStep
    {       
        [Given(@"I Search for ""(.*)"" on Google")]
        public void SearchGoogle(string searchString)
        {
            CurrentPage = GetInstance<GoogleHomePage>();
            Assert.IsTrue(CurrentPage.As<GoogleHomePage>().SearchGoogle(searchString), "Unable to Search for ");
        }

        [Given(@"Click on the link with the search link ""(.*)"" from the search results")]
        public void ClickOnSearchResult(string searchResult)
        {
            CurrentPage = CurrentPage.As<GoogleHomePage>().ClickSearchResult(searchResult);
            Assert.IsNotNull(CurrentPage,"Unable to click on the link " + searchResult + " in the search results" );
        }



    }
}
