using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using UnitTestEx;
using Assert = NUnit.Framework.Assert;

namespace UnitTestProject
{
    [TestClass]
    public class FileTest
    {
        private const string SIZE_EXCEPTION = "Wrong size";
        private const string NAME_EXCEPTION = "Wrong name";
        private const string SPACE_STRING = " ";
        private const string FILE_PATH_STRING = @"D:\JDK-intellij-downloader-info.txt";
        private const string CONTENT_STRING = "Some text";

        /* Тестируем получение размера */
        [TestMethod]
        [DataRow(FILE_PATH_STRING, CONTENT_STRING)]
        [DataRow(SPACE_STRING, SPACE_STRING)]
        public void GetSizeTest(string filePath, string content)
        {
            var newFile = new File(filePath, content);
            double expectedSize = (double)content.Length / 2;
            Assert.AreEqual(newFile.GetSize(), expectedSize, SIZE_EXCEPTION);
        }

        /* Тестируем получение имени */
        [TestMethod]
        [DataRow(FILE_PATH_STRING, CONTENT_STRING)]
        [DataRow(SPACE_STRING, SPACE_STRING)]
        public void GetFilenameTest(string filePath, string content)
        {
            var newFile = new File(filePath, content);
            Assert.AreEqual(newFile.GetFilename(), filePath, NAME_EXCEPTION);
        }

    }
}
