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
            (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository(repo.ToString());
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

        public override void Log(string message, LogType type)
        {
            switch (type)
            {
                case LogType.Error:
                    LogHelper.log.Error(message);
                    break;
                case LogType.Info:
                    LogHelper.log.Info(message);
                    break;
                case LogType.Fatal:
                    LogHelper.log.Fatal(message);
                    break;
                case LogType.Warning:
                    LogHelper.log.Warn(message);
                    break;
                default:
                    LogHelper.log.Info(message);
                    break;
            }
        }
       
       
    }
   
}
