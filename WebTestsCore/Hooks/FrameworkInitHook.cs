using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using TestFrameworkCore.Base;
using TestFrameworkCore.Config;
using TestFrameworkCore.Utils.Logger;
using WebTestsCore.Config;

namespace WebTestsCore.Hooks
{
    [Binding]
    public class FrameworkInitHook : TestInitializeHook
    {
        [BeforeTestRun]
        public static void TestRunSetup()
        {
            #region Init Test framework
            string path = Path.Combine(ConfigReader.TestResourceLocation() + @"\", "WebTestConfig.json");
            ConfigReader configReader = new ConfigReader(path);
            configReader.SetWebFrameworkSettings();
            #endregion
            #region Init Test Log
            InitializeWebSettings();
            LogHelper.CreateTestLog(Settings.TestLogTarget);
            #endregion           
        }

        [AfterTestRun]
        public static void CleanUp()
        {
            DriverContext.Driver.Close();
        }
    }
}
