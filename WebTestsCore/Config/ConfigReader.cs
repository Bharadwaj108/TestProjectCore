using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using TestFrameworkCore.Config;
using TestFrameworkCore.Utils.Logger;

namespace WebTestsCore.Config
{
    public class ConfigReader
    {
        public static IConfigurationRoot config = null;
        public string configFilePath;
        public static string TestResourceLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public ConfigReader(string configFile)
        {
            configFilePath = configFile;
            config = new ConfigurationBuilder()
            .AddJsonFile(configFile)
            .Build();
        }

        public static void GetTestEnvironment()
        {            
            Settings.TestEnvironment = config["TestEnvironment"];
        }

        public void SetWebFrameworkSettings()
        {            
            ConfigReader.GetTestEnvironment();
            Settings.TestLogTarget = (LogTarget)Enum.Parse(typeof(LogTarget), (ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("LogTarget").Value));            
            Settings.TestLogLocation = ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("testLogFileLocation").Value;
            Settings.TestLogFilePath = Path.Combine(TestResourceLocation()+@"\", Settings.TestLogLocation + @"\" + "Log - " + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log");            
            Settings.TestDataLocation = Path.Combine(TestResourceLocation() + @"\", ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("testDataLocation").Value + @"\");

            //Settings.ProjectName = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ProjectName;
            //string ScreenshotLocation = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ScreenShotLocation;
            //Settings.ScreenShotPath = Path.Combine(TestResourceLocation(), ScreenshotLocation + @"\Screenshots_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"\");
            //Settings.WebBrowser = (BrowserType)Enum.Parse(typeof(BrowserType), (WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].Browser));
            //Settings.AUT = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].AUT;

            //Settings.TestReportTarget = (ReportTarget)Enum.Parse(typeof(ReportTarget), (WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ReportTarget));
            //Settings.ExtentReportLocation = WebTestConfiguration.TestSettings.WebTestSettings[Settings.TestEnvironment].ExtentReportLocation;
            //Settings.ExtentReportFolderLocation = Path.Combine(TestResourceLocation(), Settings.ExtentReportLocation + @"\ExtentReport_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"\");
        }
    }
}
