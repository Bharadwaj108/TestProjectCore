using OpenQA.Selenium;
using System;
using System.Diagnostics;
using TestFrameworkCore.Config;

namespace TestFrameworkCore.Extensions
{
    public static class WebDriverExtension
    {
        public static IJavaScriptExecutor ExecuteJavaScript(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }
        public static void WaitWebPageLoad(this IWebDriver driver)
        {
            driver.WaitCondition(drv =>
            {
                string state = drv.ExecuteJavaScript().ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, Settings.Timeout);
        }

        internal static void WaitCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }
    }
}
