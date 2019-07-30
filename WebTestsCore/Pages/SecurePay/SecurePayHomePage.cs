using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using TestFrameworkCore.Base;
using TestFrameworkCore.Utils.Logger;
using WebTestsCore.Context;
using WebTestsCore.Utils;

namespace WebTestsCore.Pages.SecurePay
{
    public class SecurePayHomePage : BasePage
    {
        /// <summary>
        /// At the bottom of every page we have site navigation
        /// This method is using those links to navigate
        /// </summary>
        /// <param name="menuItem"></param>
        /// <returns></returns>
        public BasePage NavigateSecurePay(string navigateToMenuItem)
        {
            IWebElement lnkMenu = null;
            BasePage page = null;
            try
            {
                
                SecurePayNavigation menuItem = (SecurePayNavigation)Enum.Parse(typeof(SecurePayNavigation), (navigateToMenuItem));
                switch (menuItem)
                {
                    case SecurePayNavigation.ContactUs:
                        IList<IWebElement> liMenuLinks = DriverContext.Driver.FindElements(By.XPath("*//ul/li/a"));
                        lnkMenu = GetMenuLink("Contact Us", liMenuLinks);
                        page = GetInstance<SecurePayContactUsPage>();
                        break;
                    default:
                        break;
                }
                lnkMenu.Click();
                
                LogHelper.WriteToLog("Clicked on menu item " + navigateToMenuItem, CustomLogType.Info, "NavigatedToMenu");
            }
            catch (System.Exception ex)
            {
                LogHelper.WriteToLog(MethodBase.GetCurrentMethod().Name, ex.StackTrace);
                return null;
            }
            return page;
        }

        private IWebElement GetMenuLink(string linkText,IList<IWebElement> liMenuLinks)
        {
            IWebElement link = null;
            try
            {
                foreach (var item in liMenuLinks)
                {
                    if(string.Compare(item.Text,linkText,true) == 0)
                    {
                        link =  item;
                        break;
                    }
                }
                if (link is null)
                {
                    throw new TestException("Failed to get the link Item", CustomLogType.Error, "Item " + linkText + " not found on the web page", null, null);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return link;
        }
    }
}
