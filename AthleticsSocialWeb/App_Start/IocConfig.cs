using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Mvc;
using AthleticsSocialWeb.Common;
using AthleticsSocialWeb.Common.Log4Net;
using AthleticsSocialWeb.Common.Logging;
using AthleticsSocialWeb.Common.Nlog;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;


[assembly: WebActivator.PostApplicationStartMethod(typeof(AthleticsSocialWeb.IocConfig), "Initialize")]

namespace AthleticsSocialWeb
{
    public static class ContextDependentExtensions
    {
        public static void RegisterWithContext<TService>(
            this Container container,
            Func<IocConfig.DependencyContext, TService> contextBasedFactory)
            where TService : class
        {
            if (contextBasedFactory == null)
            {
                throw new ArgumentNullException("contextBasedFactory");
            }

            Func<TService> imp = () => contextBasedFactory(IocConfig.DependencyContext.Root);
            Func<TService> rootFactory = imp;

            container.Register(rootFactory, Lifestyle.Transient);

            // Allow the Func<DependencyContext, TService> to be 
            // injected into parent types.
            container.ExpressionBuilding += (sender, e) =>
            {
                if (e.RegisteredServiceType == typeof (TService)) return;
                var rewriter = new DependencyContextRewriter
                {
                    ServiceType = e.RegisteredServiceType,
                    ContextBasedFactory = contextBasedFactory,
                    RootFactory = rootFactory,
                    Expression = e.Expression
                };

                e.Expression = rewriter.Visit(e.Expression);
            };
        }

        private sealed class DependencyContextRewriter : ExpressionVisitor
        {
            internal Type ServiceType { get; set; }

            internal object ContextBasedFactory { get; set; }

            internal object RootFactory { get; set; }

            internal Expression Expression { get; set; }

            private Type ImplementationType
            {
                get
                {
                    var expression = Expression as NewExpression;

                    if (expression != null)
                    {
                        return expression.Constructor.DeclaringType;
                    }

                    return ServiceType;
                }
            }

            protected override Expression VisitInvocation(
                InvocationExpression node)
            {
                if (!IsRootedContextBasedFactory(node))
                {
                    return base.VisitInvocation(node);
                }

                return Expression.Invoke(
                    Expression.Constant(ContextBasedFactory),
                    Expression.Constant(
                        new IocConfig.DependencyContext(
                            ServiceType,
                            ImplementationType)));
            }

            private bool IsRootedContextBasedFactory(
                InvocationExpression node)
            {
                var expression =
                    node.Expression as ConstantExpression;

                if (expression == null)
                {
                    return false;
                }

                return ReferenceEquals(expression.Value,
                    RootFactory);
            }
        }
    }

    public static partial class IocConfig
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

           // container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
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


        [DebuggerDisplay("DependencyContext (ServiceType: {ServiceType},  ImplementationType: {ImplementationType})")]
        public class DependencyContext
        {
            internal static readonly DependencyContext Root =
                new DependencyContext();

            internal DependencyContext(Type serviceType,
                Type implementationType)
            {
                ServiceType = serviceType;
                ImplementationType = implementationType;
            }

            private DependencyContext()
            {
            }

            public Type ServiceType { get; private set; }

            public Type ImplementationType { get; private set; }
        }

       
    }
}