using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.Dependencies;
using SimpleInjector.Advanced;

[assembly: WebActivator.PostApplicationStartMethod(typeof(AthleticsSocialWeb.App_Start.IocConfig), "Initialize")]

namespace AthleticsSocialWeb.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    public static class IocConfig
    {
        /// <summary>Initialize the container and register it as MVC & Webapi Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: http://bit.ly/YE8OJj.
            var container = new Container();
           // container.Options.ConstructorResolutionBehavior = new MvcConstructorBehavior(container.Options.ConstructorResolutionBehavior);

            // register Web API controllers (important! http://bit.ly/1aMbBW0)
            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver()
                .GetControllerTypes(services.GetAssembliesResolver());
            foreach (var controllerType in controllerTypes)
                container.Register(controllerType);

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.RegisterMvcAttributeFilterProvider();

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>();

            //Startup.UserManagerFactory(), Startup.OAuthOptions.AccessTokenFormat
            container.Register(() => Startup.UserManagerFactory());
            container.Register(() => Startup.OAuthOptions.AccessTokenFormat);
            container.Register(() => GlobalConfiguration.Configuration);
        }

        public sealed class SimpleInjectorWebApiDependencyResolver
            : System.Web.Http.Dependencies.IDependencyResolver
        {
            private readonly Container _container;

            public SimpleInjectorWebApiDependencyResolver(
                Container container)
            {
                _container = container;
            }

            [DebuggerStepThrough]
            public IDependencyScope BeginScope()
            {
                return this;
            }

            [DebuggerStepThrough]
            public object GetService(Type serviceType)
            {
                return ((IServiceProvider)_container)
                    .GetService(serviceType);
            }

            [DebuggerStepThrough]
            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _container.GetAllInstances(serviceType);
            }

            [DebuggerStepThrough]
            public void Dispose()
            {
            }
        }

        public class MvcConstructorBehavior : IConstructorResolutionBehavior
        {
            private IConstructorResolutionBehavior DefaultBehavior { get; set; }

            public MvcConstructorBehavior(
                IConstructorResolutionBehavior defaultBehavior)
            {
                DefaultBehavior = defaultBehavior;
            }

            public ConstructorInfo GetConstructor(Type serviceType, Type impType)
            {
                //if (typeof(IController).IsAssignableFrom(impType) || typeof(IHttpController).IsAssignableFrom(impType))
                //{
                //    var nonDefaultConstructors =
                //        from constructor in impType.GetConstructors()
                //        where constructor.GetParameters().Length > 0
                //        select constructor;

                //    if (nonDefaultConstructors.Count() == 1)
                //        return nonDefaultConstructors.Single();
                //}

                // fall back to the container's default behavior.
                return DefaultBehavior.GetConstructor(serviceType, impType);
            }
        }
    }
}