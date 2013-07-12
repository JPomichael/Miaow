using iPow.Infrastructure.Crosscutting.Loggers;
using System.Reflection;
using System;

namespace iPow.Infrastructure.Data
{
    public static class LoggerReopsitoryManager
    {
        static ILoggerReopsitoryFactory logRepositoryFactory = new LoggerReopsitoryFactory();

        static LoggerReopsitoryManager()
        {
            //logRepositoryFactory = 
        }

        public static void SetCurrentLoggerFactory(ILoggerReopsitoryFactory logFactory)
        {
            logRepositoryFactory = logFactory;
        }

        public static ILoggerReopsitory CreateLogger()
        {
            return (logRepositoryFactory != null) ? logRepositoryFactory.CreateLogger() : null;
        }

        /// <summary>
        /// 添加文本日志记录
        /// </summary>
        /// <param name="message"></param>
        public static void AddLogInfo(string message)
        {
            var logPath = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "log.txt");
            if (!System.IO.File.Exists(logPath))
            {
                System.IO.File.Create(logPath);
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(logPath, true);
            sw.WriteLine(message);
            sw.Close();
            sw.Dispose();
        }

        public static void AddLogInfo(iPow.Infrastructure.Data.DataSys.Sys_AdminUserLog log)
        {
            var logRepository = CreateLogger();
            if (logRepository != null && log != null)
            {
                try
                {
                    logRepository.Add(log);
                    logRepository.Uow.Commit();
                }
                catch (System.Exception ex)
                { }
            }
        }

        /// <summary>
        /// 用于实体操作记录日志
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="logType"></param>
        /// <param name="operUser"></param>
        public static void AddLogInfo<T>(T entity, Infrastructure.Crosscutting.Function.LoggerType logType,
            iPow.Infrastructure.Data.DataSys.Sys_AdminUser operUser)
        {
            if (entity != null)
            {
                var log = new DataSys.Sys_AdminUserLog();

                log.AddTime = System.DateTime.Now;
                log.IpAddress = Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                log.PageUrl = Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
                log.ReferrerUrl = Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl();
                log.State = true;
                if (operUser != null)
                {
                    log.UserId = operUser.id;
                }
                log.TypeId = (int)logType;
                log.ShortMessage = logType.ToString() + " " + entity.GetType().Name;
                Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
                //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式     
                timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.Indented, timeConverter);
                log.FullMessage = json;
                AddLogInfo(log);
            }
        }

        public static void AddLogInfo(int logType, int userId, string pageUrl, string refUrl, string shortMessage, string fullMessage, string ipAddress)
        {
            var logRepository = CreateLogger();
            if (logRepository != null)
            {
                var log = new DataSys.Sys_AdminUserLog();
                log.AddTime = System.DateTime.Now;
                log.FullMessage = fullMessage;
                log.IpAddress = ipAddress;
                log.PageUrl = pageUrl;
                log.ReferrerUrl = refUrl;
                log.ShortMessage = shortMessage;
                log.State = true;
                log.TypeId = logType;
                log.UserId = userId;
                logRepository.Add(log);
                logRepository.Uow.Commit();
            }
        }
    }
}
