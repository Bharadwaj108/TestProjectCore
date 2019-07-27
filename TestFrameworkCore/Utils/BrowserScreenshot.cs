using System;
using System.IO;
using OpenQA.Selenium;
using TestFrameworkCore.Config;
using TestFrameworkCore.Base;

namespace TestFrameworkCore.Utils
{
    public class BrowserScreenshot
    {
        public static string CaptureBrowserScreenshot(string fileName)
        {
            if(!Directory.Exists(Settings.ScreenShotPath))
            {
                Directory.CreateDirectory(Settings.ScreenShotPath);
            }
            string filePath = Path.Combine(Settings.ScreenShotPath, fileName + DateTime.Now.ToString("yyyyddMHHmmss")+".png");
            Screenshot testScreenshot = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot();
            testScreenshot.SaveAsFile(filePath);
            return filePath;
        }
    }
}
