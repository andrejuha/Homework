using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Configuration;
using Homework.Interfaces;
using System.IO;
using Homework;

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


            configurator.ConfigureSourcePath(fileReader,@"C:\testreport\");
          

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

            diskReaderProvider.ProcessData(string.Empty);
        }

        [TestMethod]
        public void JsonWriterTest()
        {
            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            JsonWriterProvider JsonWriter = new JsonWriterProvider(m);

            configurator.ConfigureDestinationPath(JsonWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json"));


            JsonWriter.ProcessData("<Employees><title ><ID>1</ID ><FirstName > David </FirstName > </title > <text></text ></Employees>");

        }

        [TestMethod]
        public void DoubleProviderTestDrpJwp()
        {
            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            DiskReaderProvider diskReaderProvider = new DiskReaderProvider(m);
            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"));

            JsonWriterProvider jsonWriter = new JsonWriterProvider(m);
            configurator.ConfigureDestinationPath(jsonWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json"));


            DoubleProvider<string, string> doubleProvider = new DoubleProvider<string, string>(diskReaderProvider, jsonWriter, m);

            doubleProvider.Process();


        }

        public void DoubleProviderTestJwrJwp()
        {
            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            DiskReaderProvider diskReaderProvider = new DiskReaderProvider(m);
            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"));

            JsonWriterProvider jsonWriter = new JsonWriterProvider(m);
            configurator.ConfigureDestinationPath(jsonWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json"));


            DoubleProvider<string, string> doubleProvider = new DoubleProvider<string, string>(diskReaderProvider, jsonWriter, m);

            doubleProvider.Process();


        }

    }
}