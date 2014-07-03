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
        public void PrintTreeTest()
        {
            BinarySearchTree<int> bst = ConstructTree();
            bst.PrintTree();

        }

        [TestMethod]
        public void LookupTest()
        {
            BinarySearchTree<int> bst = ConstructTree();
            Assert.IsTrue(bst.Lookup(5));
            Assert.IsTrue(bst.Lookup(6));
            Assert.IsFalse(bst.Lookup(0));
        }


        [TestMethod]
        public void SizeTest()
        {
            BinarySearchTree<int> bst = ConstructTree(5,4,8);
            Assert.AreEqual(3, bst.Size(bst.RootNode));

            bst = ConstructTree(5);
            Assert.AreEqual(1, bst.Size(bst.RootNode));

            bst = new BinarySearchTree<int>();
            Assert.AreEqual(0, bst.Size(bst.RootNode));
        }

        [TestMethod]
        public void MaxDepthTest()
        {
            BinarySearchTree<int> bst = ConstructTree(5, 4, 8);
            Assert.AreEqual(2, bst.MaxDepth(bst.RootNode));

            bst = ConstructTree(5);
            Assert.AreEqual(1, bst.MaxDepth(bst.RootNode));

            bst = new BinarySearchTree<int>();
            Assert.AreEqual(0, bst.MaxDepth(bst.RootNode));
        }

        private static BinarySearchTree<int> ConstructTree()
        {
            string fileName = "BinarySearchTreeBasic.txt";
            string[] numbers = ExtractContent(fileName);
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            foreach (string currentNumber in numbers)
            {
                bst.Insert(int.Parse(currentNumber));
            }
            return bst;
        }

        private static BinarySearchTree<int> ConstructTree(params int[] values)
        {
            string[] numbers = values.Select(x => x.ToString()).ToArray();
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            foreach (string currentNumber in numbers)
            {
                bst.Insert(int.Parse(currentNumber));
            }
            return bst;
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
