using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Unity.RegistrationByConvention;
using Homework;
using Homework.Interfaces;

namespace Homework.Test
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class ResolveTest
    {
        public ResolveTest()
        {
            container = new UnityContainer();

            container.RegisterType<DiskReaderProvider>();

            container.RegisterType<JsonWriterProvider>();

            container.RegisterType< DoubleProvider<string, string>>();
            //container.RegisterType<IProviderBase<string, string>, DoubleProvider<string, string>>();

            container.RegisterType<IMediatorBase<string, string>, ConcreteMediator<string, string>>();


            container.RegisterType< ConcreteMediator<string, string>>();
            




        }
        private IUnityContainer container;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ResolveDiskReaderProvider()
        {
              var diskReaderProvider = container.Resolve<DiskReaderProvider>();
            Assert.IsNotNull(diskReaderProvider); // pass
        }

        [TestMethod]
        public void ResolveJsonWriter()
        {
            var diskReaderProvider = container.Resolve<JsonWriterProvider>();
            Assert.IsNotNull(diskReaderProvider); // pass
        }

        [TestMethod]
        public void ResolveDoubleProvider()
        {
            var diskReaderProvider = container.Resolve<DoubleProvider<string,string>>();
            Assert.IsNotNull(diskReaderProvider); // pass
        }
    }
}
