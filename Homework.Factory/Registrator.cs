using Homework;
using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Factory
{
    public class Registrator
    {
        static void Register()
        {
            container = new UnityContainer();

            container.RegisterType<DiskReaderProvider>();

            container.RegisterType<JsonWriterProvider>();

            container.RegisterType<DoubleProvider<string, string>>();
            //container.RegisterType<IProviderBase<string, string>, DoubleProvider<string, string>>();

            container.RegisterType<IMediatorBase<string, string>, ConcreteMediator<string, string>>();


            container.RegisterType<ConcreteMediator<string, string>>();
        }
    }
}
