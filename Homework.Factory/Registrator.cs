using Homework;
using Homework.Interfaces;
using Homework.Provider;
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

            container.RegisterType<XmlReaderProvider>("XmlReaderProvider");
            container.RegisterType<XmlWriterProvider>("XmlWriterProvider");

            container.RegisterType<JsonWriterProvider>("JsonWriterProvider");
            container.RegisterType<JsonReaderProvider>("JsonReaderProvider");
           
            container.RegisterType<CloudWriterProvider>("CloudWriterProvider");
            container.RegisterType<ICloudReaderProvider,CloudReaderProvider>();

            container.RegisterType<IDoubleProvider<string, string>, DoubleProvider<string, string>>();
            //container.RegisterType<IProviderBase<string, string>, DoubleProvider<string, string>>();

            container.RegisterType<IMediator<string, string>, ConcreteMediator<string, string>>();
            //container.RegisterType<IMediatorBase<string, string>, MediatorBase<string, string>>();
            

            container.RegisterType<ConcreteMediator<string, string>>();

            return container;
        }
    }
}
