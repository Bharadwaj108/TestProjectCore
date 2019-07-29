using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;
using TestFrameworkCore.Base;
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
            Settings.WedDriverPath = Path.Combine(TestResourceLocation() + @"\", ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("webDriverLocation").Value + @"\");

            Settings.ProjectName = ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("projectName").Value; 
            string ScreenshotLocation = ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("screenShotLocation").Value;
            Settings.ScreenShotPath = Path.Combine(TestResourceLocation() + @"\", ScreenshotLocation + @"\Screenshots_" + DateTime.Now.ToString("yyyyMMddHHmmss") + @"\");
            Settings.WebBrowser = (BrowserType)Enum.Parse(typeof(BrowserType), (ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("browser").Value));
            Settings.AUT = ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("applicationUnderTest").Value;
            Settings.SearchEngineUrl = ConfigReader.config.GetSection(Settings.TestEnvironment).GetSection("searchEngineUrl").Value;            
        }
    }
}
