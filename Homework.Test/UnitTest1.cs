using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Configuration;
using Homework.Interfaces;

namespace Homework.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void  ConfigurationTest()

        {
           
            Configurator configurator = new Configurator();

            IConfigurable fileReader = new ConfigureBase();


            configurator.ConfigurePath(fileReader,@"C:\report\");


        }
        [TestMethod]
        public void ProviderTest1()

        {

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();



            ReaderProvider c1 = new ReaderProvider(m);

            WriterProvider c2 = new WriterProvider(m);



            m.ReaderProvider = c1;

            m.WriterProvider = c2;



            c1.ForwardData("How are you?");

            c2.ForwardData("Fine, thanks");


        }
    }
}
