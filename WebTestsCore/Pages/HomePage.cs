using OpenQA.Selenium;
using System.Threading;
using TestFrameworkCore.Base;

namespace WebTestsCore.Pages
{
    public class HomePage : BasePage
    {
        /// <summary>
        /// Navigate through the Officeworks main menu on the top of the page
        /// </summary>
        /// <param name="product"></param>        
        /// <returns></returns>
        public ItemsPage NavigateMainMenu(string productCategory)
        {
            try
            {
                IWebElement mainMenuContainer = DriverContext.Driver.FindElement(By.XPath("//div[@data-ref = 'mega-menu-link-technology']"));
                switch (productCategory.Trim().ToLower())
                {
                    case "school essentials":
                        //to be implimented when necessary
                        break;
                    case "office supplies":
                        //to be implimented when necessary
                        break;
                    case "art supplies":
                        //to be implimented when necessary
                        break;
                    case "technology":
                        IWebElement lnkTechnology = mainMenuContainer.FindElement(By.XPath("//a[text()='Technology']"));
                        lnkTechnology.Click();
                        //ToDo : Implicit Fluient wait by writing a Wait utility
                        Thread.Sleep(3000);
                        //ToDo:Check to see if you have navigated to the Technology section,if fails retun null and log error
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception)
            {
                //Log Error
                return null;
            }
            return GetInstance<ItemsPage>();
        }

    }
}
