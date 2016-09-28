using Castle.MicroKernel.Registration;
using Castle.DynamicProxy;
using Castle.Core;

namespace ImageMerger
{
    public class LogInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container
                    .Register(Component.For<IInterceptor>().ImplementedBy<LogInterceptor>().Named("LogInterceptor"))
                    .Register(Component.For<IApplicationConfigParameters>().ImplementedBy<ApplicationConfigParameters>().LifestyleTransient().Interceptors(InterceptorReference.ForKey("LogInterceptor")).Anywhere);

        }
    }
}
