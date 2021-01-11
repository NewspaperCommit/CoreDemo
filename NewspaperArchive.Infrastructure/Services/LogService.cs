using AutoMapper;
using log4net;
using log4net.Config;
using NewspaperArchive.Application.Common.DTO;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace NewspaperArchive.Infrastructure.Services
{   
    public class LogService : ILoggerService
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LogService));
        public LogService()
        {
           try
            {              
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4netConfig.Load(fs);
                    var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                    _logger.Info("Log System Initialized");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }
        public void LogInformation(string message)
        {
           _logger.Info(message);
        }
        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}
