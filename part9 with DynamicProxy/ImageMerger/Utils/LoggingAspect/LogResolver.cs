using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;

namespace ImageMerger
{
    public class LogResolver
    {
        private static IWindsorContainer container = new WindsorContainer();
        private static LogResolver instance;

        private LogResolver()
        {
        }

        public static LogResolver GetInstance()
        {
            if (instance == null)
            {
                instance = new LogResolver();
            }

            return instance;
        }

        public <T> GetResolver(object obj) 
    }
}
