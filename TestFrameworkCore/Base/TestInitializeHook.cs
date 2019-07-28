using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using TestFrameworkCore.Config;
using TestFrameworkCore.Utils.Logger;

namespace TestFrameworkCore.Base
{
    public class TestInitializeHook :Steps
    {       
        public static void InitializeWebSettings()
        {
            //Set all the settings for framework
            //ConfigReader.SetWebFrameworkSettings();

            //Open Browser
            OpenBrowser(Settings.WebBrowser);
            //DriverContext.Browser.GoToUrl(Settings.AUT);

        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.Chrome)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:                   
                    break;
                case BrowserType.FireFox:                    
                    break;
                case BrowserType.Chrome:
                    //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", Settings.WedDriverPath +@"\chromedriver.exe");
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    DriverContext.Driver = new ChromeDriver(Settings.WedDriverPath,options);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }

        }

        public virtual void NaviateSite()
        {
            DriverContext.Browser.GoToUrl(Settings.AUT);
            LogHelper.WriteToLog("Opened the browser !!!");
        }
    }
}
