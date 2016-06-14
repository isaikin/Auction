using System;
using log4net;
using log4net.Config;

namespace DAOSQLSERVER
{
    internal class Log
    {
        static Log()
        {
            XmlConfigurator.Configure();
        }

        public static ILog For(object loggedObject)
        {
            if (loggedObject != null)
            {
                return For(loggedObject.GetType());
            }
            else
            { 
                return For(null);
            }
        }

        public static ILog For(Type objectType)
        {
            if (objectType != null)
            {
                return LogManager.GetLogger(objectType.Name);
            }
            else
            {
                return LogManager.GetLogger(string.Empty);
            }
        }
    }
}