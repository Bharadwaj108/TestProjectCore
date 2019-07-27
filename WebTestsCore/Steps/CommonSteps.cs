using NUnit.Framework;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using WebTestsCore.Config;

namespace WebTests.Steps
{
    [Binding]
    public class CommonSteps
    {
        public static string TestResourceLocation()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        [Given(@"I navigate to the Officeworks website")]
        public void GivenINavigateToTheOfficeworksWebsite()
        {
            //string path = Path.Combine(TestResourceLocation() +@"\","WebTestConfig.json");
            ////string path = Path.Combine(@"C:\Bharat\Work\AutomationFrameworks\TestProjectCore\WebTestsCore\bin\Debug\netcoreapp2.1\", "WebTestConfig.json");
            //ConfigReader configReader = new ConfigReader(path);
            //configReader.GetTestEnvironment();
            //configReader.config.GetSection(TestFrameworkCore.Config.Settings.TestEnvironment);
            string path = Path.Combine(TestResourceLocation() + @"\", "WebTestConfig.json");
            ConfigReader configReader = new ConfigReader(path);
            configReader.SetWebFrameworkSettings();
        }



    }
}
