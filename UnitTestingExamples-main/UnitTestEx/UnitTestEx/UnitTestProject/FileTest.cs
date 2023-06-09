﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private const string FILE_PATH_STRING = "docs/report.txt";
        private const string CONTENT_STRING = "Some text";
        public const string WRONG_SIZE_CONTENT_STRING = "TEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtextTEXTtext";
        private const string EMPTY_CONTENT = "";

        /*
         *В этом файле вместо использования списков, я задаю переменные отдельно для каждого метода
        */

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

        /*Тестирование конструктора класса*/
        [TestMethod]
        [DataRow(FILE_PATH_STRING, CONTENT_STRING)] //Данные файла
        [DataRow(SPACE_STRING, SPACE_STRING)]
        public void TestConstructor(string filePath, string content)
        {
            File file = new File(filePath, content); //конструктор класса

            Assert.IsNotNull(file); //Проверка, что файл не null
            Assert.AreEqual(filePath, file.GetFilename()); //Проверка совпадения пути файла и его имени
            Assert.AreEqual(content.Length / 2.0, file.GetSize()); //Проверка совпадения размера файла
        }

        /*Тестирование слишком большого файла*/
        [TestMethod]
        [DataRow(FILE_PATH_STRING, WRONG_SIZE_CONTENT_STRING)]
        [DataRow(SPACE_STRING, SPACE_STRING)]
        public void TestFileWithLongContent(string filePath, string content)
        {
            File file = new File(filePath, content); //конструктор класса
            double actualSize = file.GetSize(); //объявление текущего размера файла
            Assert.AreEqual(content.Length / 2.0, actualSize); //Проверка совпадения размера файла с текущим размером
        }

        [TestMethod]
        [DataRow(FILE_PATH_STRING, EMPTY_CONTENT)]
        [DataRow(SPACE_STRING, SPACE_STRING)]
        public void TestFileWithEmptyContent(string filePath, string content)
        {
            File file = new File(filePath, content); //конструктор класса
            int actualSize = (int)file.GetSize(); //объявление текущего размера файла
            Assert.AreEqual(0, actualSize); //проверка, имеет ли файл размер
        }
    }
}
