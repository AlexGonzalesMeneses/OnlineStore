using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Api.Services
{
    public interface ILoggerManager
    {
        void LogInfo(Exception e);
        void LogWarn(Exception e);
        void LogDebug(Exception e);
        void LogError(Exception e);
    }
}
