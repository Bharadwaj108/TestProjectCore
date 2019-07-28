using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using TestFrameworkCore.Utils.Logger;
using TestFrameworkCore.Utils.Reporter;

namespace TestFrameworkCore.Config
{
    public class Settings
    {
        public static string TestEnvironment { get; set; }
        public static LogTarget TestLogTarget { get; set; }
        public static ReportTarget TestReportTarget { get; set; }
        public static string TestLogFilePath { get; set; }
        public static string TestLogLocation { get; set; }
        public static string TestDataLocation { get; set; }
        public static string ExtentReportFolderLocation { get; set; }
        public static string ExtentReportLocation { get; set; }        
        public static string ProjectName { get; set; }
        public static BrowserType WebBrowser { get; set; }
        public static string AUT { get; set; }
        public static string ScreenShotPath { get; set; }
        public static ScenarioContext ScenarioContext { get; set; }
        public static string WedDriverPath { get; set; }
    }
}
