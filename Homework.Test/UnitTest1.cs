using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Configuration;
using Homework.Interfaces;
using System.IO;

namespace Homework.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void  ConfigurationTest()

        {
           
            Configurator configurator = new Configurator();


            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            IConfigurable fileReader = new DiskReaderProvider(m);


            configurator.ConfigureSourcePath(fileReader,@"C:\report\");


        }
        [TestMethod]
        public void DummyProviderTest1()

        {

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();



            ReaderProvider c1 = new ReaderProvider(m);

            WriterProvider c2 = new WriterProvider(m);



            m.ReaderProvider = c1;

            m.WriterProvider = c2;



            c1.ForwardData("How are you?");

            c2.ForwardData("Fine, thanks");


        }

        [TestMethod]
        public void DiskReaderTest()
        {
            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            DiskReaderProvider diskReaderProvider = new DiskReaderProvider(m);

            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"));
            configurator.ConfigureDestinationPath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json"));

        
        }

        [TestMethod]
        public void JsonWriterTest()
        {
        }

        }
}