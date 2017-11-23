﻿using System;
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
    public class UnitTest2
    {
        public UnitTest2()
        {
            container = new UnityContainer();
    //        container.RegisterTypes(
    //AllClasses.FromLoadedAssemblies(),
    //WithMappings.FromMatchingInterface,
    //WithName.Default);


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

            container.RegisterType< DiskReaderProvider >();

            container.RegisterType< IMediatorBase <string, string> ,ConcreteMediator <string,string>>();
            //ConcreteMediator<string, string> concreteMediator = container.Resolve<ConcreteMediator<string, string>>();

              var diskReaderProvider = container.Resolve<DiskReaderProvider>();
            Assert.IsNotNull(diskReaderProvider); // pass
        }
    }
}