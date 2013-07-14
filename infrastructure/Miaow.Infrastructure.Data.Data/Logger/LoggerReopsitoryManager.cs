using Miaow.Infrastructure.Crosscutting.Loggers;
using System.Reflection;
using System;

namespace Miaow.Infrastructure.Data
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

        public static void AddLogInfo(Miaow.Infrastructure.Data.DataSys.sys_logs log)
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
            Miaow.Infrastructure.Data.DataSys.sys_logs operUser)
        {
            if (entity != null)
            {
                var log = new DataSys.sys_logs();
                log.created_time = System.DateTime.Now;
                log.netaddress = Infrastructure.Crosscutting.Function.StringHelper.GetRealIP();
                log.page_url = Infrastructure.Crosscutting.Function.StringHelper.GetCurrentUrl();
                log.referrer_url = Infrastructure.Crosscutting.Function.StringHelper.GetReferrerUrl();
                log.deleted = 0;  //0显示  ：1不显示
                if (operUser != null)
                {
                    log.admin_id = operUser.admin_id;
                }
                log.type_Id= (int)logType;
                log.log_title = logType.ToString() + " " + entity.GetType().Name;

                Newtonsoft.Json.Converters.IsoDateTimeConverter timeConverter = new
                    Newtonsoft.Json.Converters.IsoDateTimeConverter();
                //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式     
                timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(entity, 
                    Newtonsoft.Json.Formatting.Indented, timeConverter);
                log.remark = json;
                AddLogInfo(log);
            }
        }

        public static void AddLogInfo(int logType, int userId, string pageUrl, string refUrl, string shortMessage, string fullMessage, string ipAddress)
        {
            var logRepository = CreateLogger();
            if (logRepository != null)
            {
                var log = new DataSys.sys_logs();
                
                log.created_time = System.DateTime.Now;
                log.remark = fullMessage;
                log.netaddress= ipAddress;
                log.page_url = pageUrl;
                log.referrer_url = refUrl;
                log.log_title = shortMessage;
                log.deleted = 0;
                log.type_Id = logType;
                log.admin_id = userId;
                logRepository.Add(log);
                logRepository.Uow.Commit();
            }
        }
    }
}
