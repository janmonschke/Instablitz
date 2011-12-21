using Instablitz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestInstablitz
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ConfigDataTest" und soll
    ///alle ConfigDataTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ConfigDataTest
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
        ///Ein Test für "IsUserAuthenticated"
        ///</summary>
        [TestMethod()]
        public void IsUserAuthenticatedTest()
        {
            // should return false for empty Config Data
            ConfigData target = new ConfigData();
            Assert.IsFalse(target.IsUserAuthenticated());

            target.oauth_token = "aasdoh0e9h8füin";
            Assert.IsFalse(target.IsUserAuthenticated());

            target.oauth_token = null;
            target.oauth_token_secret = "038tzhüi0hü0s8egspdfnpn++";
            Assert.IsFalse(target.IsUserAuthenticated());

            // should only work when both are set
            target.oauth_token = "aasdoh0e9h8füin";
            Assert.IsTrue(target.IsUserAuthenticated());
        }
    }
}
