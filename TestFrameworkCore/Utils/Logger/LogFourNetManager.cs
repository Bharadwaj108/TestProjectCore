using System;
using System.IO;
using TestFrameworkCore.Config;
using log4net;
using log4net.Appender;
using log4net.Config;
using System.Xml;
using System.Reflection;
using log4net.Repository;

namespace TestFrameworkCore.Utils.Logger
{
    public class LogFourNetManager : LogBase
    {
        public static void ConfigureLogFile(string logFileLocation)
        {            
            XmlDocument log4netConfig = new System.Xml.XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                       typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

            log4net.Repository.Hierarchy.Hierarchy h =
            (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository(repo.Name.ToString());
            foreach (IAppender a in h.Root.Appenders)
            {
                if (a is FileAppender)
                {
                    FileAppender fa = (FileAppender)a;
                    fa.File = logFileLocation;
                    fa.ActivateOptions();
                    break;
                }
            }
        }

        public override void Log(string message)
        {
            LogHelper.log.Info(message);
        }

        public override void Log(string message, CustomLogType type)
        {
            switch (type)
            {
                case CustomLogType.Error:
                    LogHelper.log.Error(message);
                    break;
                case CustomLogType.Info:
                    LogHelper.log.Info(message);
                    break;
                case CustomLogType.Fatal:
                    LogHelper.log.Fatal(message);
                    break;
                case CustomLogType.Warning:
                    LogHelper.log.Warn(message);
                    break;
                default:
                    LogHelper.log.Info(message);
                    break;
            }
        }

        public override void Log(string message, CustomLogType type, string addtionalInfo)
        {
            switch (type)
            {
                case CustomLogType.Error:
                    LogHelper.log.Error(message);
                    LogHelper.log.Error(addtionalInfo);
                    break;
                case CustomLogType.Info:
                    LogHelper.log.Info(message);
                    LogHelper.log.Info(addtionalInfo);
                    break;
                case CustomLogType.Fatal:
                    LogHelper.log.Fatal(message);
                    LogHelper.log.Fatal(addtionalInfo);
                    break;
                case CustomLogType.Warning:
                    LogHelper.log.Warn(message);
                    LogHelper.log.Warn(addtionalInfo);
                    break;
                default:
                    LogHelper.log.Info(message);
                    LogHelper.log.Info(addtionalInfo);
                    break;
            }
        }
    }
   
}
