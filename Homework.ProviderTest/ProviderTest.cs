using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.Configuration;
using Homework.Interfaces;
using System.IO;
using Homework;

namespace Homework.Test
{
    [TestClass]
    public class ProviderTest
    {
        [TestMethod]
        public void ConfigurationTest()

        {

            Configurator configurator = new Configurator();


            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            IConfigurable fileReader = new XmlReaderProvider(m);


            configurator.ConfigureSourcePath(fileReader, @"C:\testreport\");

            Assert.AreEqual(@"C:\testreport\", ((ConfigureBase)fileReader).GetParam(6).Value);

        }


        [TestMethod]
        public void XmlReaderProvider()
        {

            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            XmlReaderProvider diskReaderProvider = new XmlReaderProvider(m);

            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"));

            diskReaderProvider.ProcessData(string.Empty);
        }

        [TestMethod]
        public void JsonWriterTest()
        {
            EmptyDirectory(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files"));

            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            JsonWriterProvider JsonWriter = new JsonWriterProvider(m);

            configurator.ConfigureDestinationPath(JsonWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json"));


            JsonWriter.ProcessData("<Employees><title ><ID>1</ID ><FirstName > David </FirstName > </title > <text></text ></Employees>");

            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json")));
        }


        [TestMethod]
        public void JsonReaderTest()
        {
            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();
            JsonReaderProvider diskReaderProvider = new JsonReaderProvider(m);
            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document2.json"));
            diskReaderProvider.ProcessData(null);
        }

        [TestMethod]
        public void DoubleProviderTestXmlToJson()
        {
            EmptyDirectory(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files"));

            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            XmlReaderProvider diskReaderProvider = new XmlReaderProvider(m);
            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"));

            JsonWriterProvider jsonWriter = new JsonWriterProvider(m);
            configurator.ConfigureDestinationPath(jsonWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json"));


            DoubleProvider<string, string> doubleProvider = new DoubleProvider<string, string>(diskReaderProvider, jsonWriter, m);

            doubleProvider.Process();

            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.json")));


        }

        [TestMethod]
        public void DoubleProviderTestJsonToXml()
        {
            EmptyDirectory(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files"));

            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            JsonReaderProvider diskReaderProvider = new JsonReaderProvider(m);
            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document2.json"));

            XmlWriterProvider xmlWriter = new XmlWriterProvider(m);
            configurator.ConfigureDestinationPath(xmlWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.xml"));


            DoubleProvider<string, string> doubleProvider = new DoubleProvider<string, string>(diskReaderProvider, xmlWriter, m);

            doubleProvider.Process();

            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.xml")));

        }
        [TestMethod]
        public void DoubleProviderTestXmlToCloud()
        {

            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            XmlReaderProvider diskReaderProvider = new XmlReaderProvider(m);
            configurator.ConfigureSourcePath(diskReaderProvider, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Source Files\\Document1.xml"));

            CloudWriterProvider writerProvider = new CloudWriterProvider(m);
            configurator.ConfigureDestinationPath(writerProvider, Path.Combine("cloudPath", "\\cloudDirectory"));
            configurator.ConfigureUserName(writerProvider, "testUser");
            configurator.ConfigurePassword(writerProvider, "testPassword");
            configurator.ConfigureUrl(writerProvider, "cloudUrl");

            DoubleProvider<string, string> doubleProvider = new DoubleProvider<string, string>(diskReaderProvider, writerProvider, m);

            doubleProvider.Process();


        }
        [TestMethod]
        public void DoubleProviderTestCloudToXml()
        {

            EmptyDirectory(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files"));

            Configurator configurator = new Configurator();

            ConcreteMediator<string, string> m = new ConcreteMediator<string, string>();

            CloudReaderProvider ReaderProvider = new CloudReaderProvider(m);
            configurator.ConfigureSourcePath(ReaderProvider, Path.Combine("cloudPath", "\\cloudDirectory"));
            configurator.ConfigureUserName(ReaderProvider, "testUser");
            configurator.ConfigurePassword(ReaderProvider, "testPassword");
            configurator.ConfigureUrl(ReaderProvider, "cloudUrl");

            XmlWriterProvider xmlWriter = new XmlWriterProvider(m);
            configurator.ConfigureDestinationPath(xmlWriter, Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.xml"));


            DoubleProvider<string, string> doubleProvider = new DoubleProvider<string, string>(ReaderProvider, xmlWriter, m);

            doubleProvider.Process();

            Assert.IsTrue(File.Exists(Path.Combine(Environment.CurrentDirectory, "..\\..\\..\\Target Files\\Document1.xml")));



        }

        public static void EmptyDirectory(string path)
        {
            System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(path);
            foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
        }
    }
}