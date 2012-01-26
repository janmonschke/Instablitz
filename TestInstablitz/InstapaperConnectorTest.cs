using Instablitz;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InstaBlitz;
using System.Windows.Forms;
using System.Collections.Generic;
using InstaBlitz.Models;

namespace TestInstablitz
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "InstapaperConnectorTest" und soll
    ///alle InstapaperConnectorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class InstapaperConnectorTest
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
        ///Ein Test für "GetFolderList"
        ///</summary>
        [TestMethod()]
        public void GetFolderListTest()
        {
            Login l = new Login();
            WebBrowser wb = l.GetBrowserElement();
            wb.DocumentCompleted += delegate (Object sender, WebBrowserDocumentCompletedEventArgs args){
                OAuthHelper h = new OAuthHelper(wb); // TODO: Passenden Wert initialisieren
                InstapaperConnector target = new InstapaperConnector(h); // TODO: Passenden Wert initialisieren
                User user = new User(target);
                target.GetFolderList(user, delegate(IAsyncResult result)
                {
                    // Should return an empty List in case of zero folders
                    Console.WriteLine(user.Folders);
                    if (user.Folders.Capacity > 0)
                        foreach (Folder f in user.Folders)
                            Assert.IsNotNull(f);
                });
            };
            
        }

        /// <summary>
        ///Ein Test für "GetBookmarks"
        ///</summary>
        [TestMethod()]
        public void GetBookmarksTest()
        {
            Login l = new Login();
            WebBrowser wb = l.GetBrowserElement();
            wb.DocumentCompleted += delegate(Object sender, WebBrowserDocumentCompletedEventArgs args)
            {
                OAuthHelper h = new OAuthHelper(wb); // TODO: Passenden Wert initialisieren
                InstapaperConnector target = new InstapaperConnector(h); // TODO: Passenden Wert initialisieren
                Folder folder = new Folder(target);
                folder.Id = Folder.STARRED;
                folder.GetBookmarks(delegate(IAsyncResult result)
                {
                    // Should return an empty List in case of zero folders
                    
                    if (folder.Bookmarks.Count > 0)
                        foreach (Bookmark b in folder.Bookmarks)
                            Assert.IsNotNull(b);
                });
                 
            };

        }
    }
}
