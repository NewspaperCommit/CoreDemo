//using log4net;
//using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace NewspaperArchive.Application.Services
{
    public interface ILoggerService
    {
        void LogInformation(string message);
    }
    
}
