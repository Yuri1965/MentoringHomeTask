using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace ImageMerger
{
    public static class LogContainerManager
    {
        public static readonly IWindsorContainer Container;

        static LogContainerManager()
        {
            Container = new WindsorContainer();
            Container.Install(FromAssembly.This());
        }
    }
}
