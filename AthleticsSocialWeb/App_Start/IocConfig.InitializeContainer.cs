using System;
using System.Collections.Generic;
using System.Web.Http;
using AthleticsSocialWeb.Common.Log4Net;
using AthleticsSocialWeb.Common.Logging;
using AthleticsSocialWeb.Common.Nlog;
using SimpleInjector;

namespace AthleticsSocialWeb
{
    public static partial class IocConfig
    {
        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();

            container.Register(() => Startup.UserManagerFactory());
            container.Register(() => Startup.OAuthOptions.AccessTokenFormat);
            container.Register(() => GlobalConfiguration.Configuration);


            // container.RegisterSingle<ILoggerFactory, NLogLoggerFactory>();

            //container.RegisterWithContext(context => 
            //     container.GetInstance<ILoggerFactory>().Create(context.ImplementationType));

            // container.Register<ILogger>(() => new NLogLogger(container.GetType()));
            container.RegisterWithContext<ILogger>(context =>
                new CompositeLogger(LoggerTypeEnum.Log4Net,
                    new List<Tuple<LoggerTypeEnum, ILogger>>
                    {
                        new Tuple<LoggerTypeEnum, ILogger>(LoggerTypeEnum.Nlog,
                            new NLogLogger(context.ImplementationType)),
                        new Tuple<LoggerTypeEnum, ILogger>(LoggerTypeEnum.Log4Net,
                            new Log4NetLogger(context.ImplementationType))
                    }));
        }
    }
}