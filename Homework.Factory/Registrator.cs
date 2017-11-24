using Homework;
using Homework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Homework.Factory
{
    public class Registrator
    {
        public static UnityContainer Register()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<XmlReaderProvider>();

            container.RegisterType<JsonWriterProvider>();

            container.RegisterType<DoubleProvider<string, string>>();
            //container.RegisterType<IProviderBase<string, string>, DoubleProvider<string, string>>();

            container.RegisterType<IMediatorBase<string, string>, ConcreteMediator<string, string>>();


            container.RegisterType<ConcreteMediator<string, string>>();

            return container;
        }
    }
}
