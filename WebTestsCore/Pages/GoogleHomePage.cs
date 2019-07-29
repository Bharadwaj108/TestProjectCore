using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using TestFrameworkCore.Base;
using TestFrameworkCore.Config;
using TestFrameworkCore.Utils.Logger;
using WebTestsCore.Pages.SecurePay;

namespace WebTestsCore.Pages
{
    public class GoogleHomePage : BasePage
    {
        public bool SearchGoogle(string searchString)
        {
            bool flag = false;
            try
            {
                //Navigate to Google web page
                DriverContext.Browser.GoToUrl(Settings.SearchEngineUrl);

                //Search the website
                IWebElement txtSearch = DriverContext.Driver.FindElement(By.XPath("*//input[@type='text' and contains(@title, 'Search')]"));
                txtSearch.SendKeys(searchString);
                txtSearch.SendKeys(Keys.Enter);
                //ToDo:Remove the hardcoded dealy and wait for the page to load
                Thread.Sleep(10000);
                LogHelper.WriteToLog("Google Search Successful for " + searchString,CustomLogType.Info,"GoogleSearchResults");
                flag = true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                return false;
            }
            return flag;
        }

        public SecurePayHomePage ClickSearchResult(string searchResultsLink)
        {
            try
            {
                IWebElement linkSecurePay = DriverContext.Driver.FindElement(By.XPath("*//a[@href='"+ searchResultsLink + "']"));
                linkSecurePay.Click();
                //ToDo:Remove the hardcoded dealy and wait for the page to load
                Thread.Sleep(10000);
                LogHelper.WriteToLog("Clicked on the link " + searchResultsLink + " in the search results", CustomLogType.Info, "ClickedSEarchResult");
            }
            catch (Exception ex)
            {
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                return null;
            }
            return GetInstance<SecurePayHomePage>();
        }
    }
}
