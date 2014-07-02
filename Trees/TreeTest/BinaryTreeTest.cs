using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;
using System.Linq;

namespace TreeTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void ConstructTree()
        {
            string fileName = "BinarySearchTreeBasic.txt";
            string[] numbers = ExtractContent(fileName);
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            foreach (string currentNumber in numbers)
            {
                bst.Insert(int.Parse(currentNumber));
            }


        }

        private static string[] ExtractContent(string fileName)
        {
            string content = string.Empty;
            using (StreamReader reader = new StreamReader(fileName))
            {
                content = reader.ReadToEnd();
            }
            string[] numbers = content.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            return numbers;
        }
    }
}
