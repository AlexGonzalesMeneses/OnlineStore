using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Api.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(Exception e)
        {
            logger.Debug(e);
        }

        public void LogError(Exception e)
        {
            logger.Error(e);
        }

        public void LogInfo(Exception e)
        {
            logger.Info(e);
        }

        public void LogWarn(Exception e)
        {
            logger.Warn(e);
        }
    }
}
