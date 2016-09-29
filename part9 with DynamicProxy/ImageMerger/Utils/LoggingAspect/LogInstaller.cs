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
                    .Register(Component.For<IApplicationConfigParameters>().ImplementedBy<ApplicationConfigParameters>().LifestyleTransient())
                    .Register(Component.For<IImageWatcherService>().ImplementedBy<ImageWatcherService>().LifestyleTransient())
                    .Register(Component.For<IDirectoryWatchManager>().ImplementedBy<DirectoryWatchManager>().LifestyleTransient())
                    .Register(Component.For<IImageProcessor>().ImplementedBy<ImageProcessor>().LifestyleTransient())
                    .Register(Component.For<IImageToPdfFileMerger>().ImplementedBy<ImageToPdfFileMerger>().LifestyleTransient());
        }
    }
}
