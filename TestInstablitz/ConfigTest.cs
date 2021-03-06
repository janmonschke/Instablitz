﻿using Instablitz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestInstablitz
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ConfigTest" und soll
    ///alle ConfigTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ConfigTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
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

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "Write"
        ///</summary>
        [TestMethod()]
        public void WriteTest()
        {
            ConfigData cd = Config.GetData();
            cd.oauth_token = "";
            cd.oauth_token_secret = "";
            Config.Write();

            // test if file exists
            Assert.IsTrue(File.Exists(ConfigData.FILENAME));
        }

        /// <summary>
        ///Ein Test für "GetData"
        ///</summary>
        [TestMethod()]
        public void GetDataTest()
        {
            ConfigData expected = new ConfigData();
            ConfigData actual;
            actual = Config.GetData();

            // Both objects should have the same value
            Assert.AreEqual(expected.oauth_token, actual.oauth_token);
            Assert.AreEqual(expected.oauth_token_secret, actual.oauth_token_secret);
            Assert.AreEqual(expected.developer_mode, actual.developer_mode);

            // Check for file on disk
            Assert.IsTrue(File.Exists(ConfigData.FILENAME));
        }

        /// <summary>
        ///Ein Test für "Delete"
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            // Delete() should not fail if no file exists
            Config.Delete();
            Assert.IsFalse(File.Exists(ConfigData.FILENAME));

            // Create and delete a config file
            ConfigData cd = Config.GetData();
            Config.Delete();
            Assert.IsFalse(File.Exists(ConfigData.FILENAME));
        }
    }
}
