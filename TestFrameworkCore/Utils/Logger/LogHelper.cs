using System;
using System.Reflection;
using TestFrameworkCore.Config;
using log4net;

namespace TestFrameworkCore.Utils.Logger
{
    public static class LogHelper
    {
        public static ILog log;
        private static LogBase logger = null;

        public static void CreateTestLog(LogTarget logTarget)
        {
            switch (logTarget)
            {
                case LogTarget.Log4Net:
                    LogFourNetManager.ConfigureLogFile(Settings.TestLogFilePath);
                    log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);                    
                    break;
                case LogTarget.Text:
                    break;
                default:
                    break;
            }
        }

        public static void WriteToLog(string message)
        {
            switch (Settings.TestLogTarget)
            {
                case LogTarget.Log4Net:
                    if (logger is null)
                        logger = new LogFourNetManager();
                    logger.Log(message);
                    break;
                case LogTarget.Text:
                    break;
                default:
                    break;
            }           
        }

        public static void WriteToLog(string message,CustomLogType logType)
        {
            switch (Settings.TestLogTarget)
            {
                case LogTarget.Log4Net:
                    if (logger is null)
                        logger = new LogFourNetManager();
                    logger.Log(message, logType);
                    break;
                case LogTarget.Text:
                    break;
                default:
                    break;
            }            
        }

        public static void WriteToLog(string message, CustomLogType logType, string screenShotFileName)
        {
            switch (Settings.TestLogTarget)
            {
                case LogTarget.Log4Net:
                    if (logger is null)
                        logger = new LogFourNetManager();
                    logger.Log(message, logType);
                    //ToDo:Add the time stamp to the screenshot file
                    string screenshotFilePath = BrowserScreenshot.CaptureBrowserScreenshot(screenShotFileName);
                    logger.Log("Screenshot added to loaction : " + screenshotFilePath, logType);                    
                    break;
                case LogTarget.Text:
                    break;
                default:
                    break;
            }
        }

        public static void WriteToLog(string message, CustomLogType logType, string addtionalInfo ,string screenShotFileName)
        {
            switch (Settings.TestLogTarget)
            {
                case LogTarget.Log4Net:
                    if (logger is null)
                        logger = new LogFourNetManager();
                    logger.Log(message, logType, addtionalInfo);
                    string screenshotFilePath = BrowserScreenshot.CaptureBrowserScreenshot(screenShotFileName);
                    logger.Log("Screenshot added to loaction : " + screenshotFilePath, logType);
                    break;
                case LogTarget.Text:
                    break;
                default:
                    break;
            }
        }

        public static void WriteToLog(object obj, string exceptionMessage)
        {
            switch (Settings.TestLogTarget)
            {
                case LogTarget.Log4Net:
                    if (logger is null)
                        logger = new LogFourNetManager();
                    logger.Log(DateTime.Now.ToString("yyyyMMdd-HH.mm.ss") + ":  " + obj + ":  " + exceptionMessage);
                    break;
                case LogTarget.Text:
                    break;
                default:
                    break;
            }            
        }
    }
}
