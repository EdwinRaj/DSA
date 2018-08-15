using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;

namespace TreeTest
{
    [TestClass]
    public class UdemyBinaryTreeTest
    {
        [TestMethod]
        public void TestPreOrder()
        {
            var tree = new UdemyBinaryTrees();
            var rootNode = tree.CreateTree();
            tree.PreOrderTraversal(rootNode);
        }

        [TestMethod]
        public void TestInOrder()
        {
            var tree = new UdemyBinaryTrees();
            var rootNode = tree.CreateTree();
            tree.InOrderTraversal(rootNode);
        }

        [TestMethod]
        public void TestPostOrder()
        {
            var tree = new UdemyBinaryTrees();
            var rootNode = tree.CreateTree();
            tree.PostOrderTraversal(rootNode);
        }

        [TestMethod]
        public void TestLevelOrder()
        {
            var tree = new UdemyBinaryTrees();
            var rootNode = tree.CreateTree();
            tree.LevelOrderTraversal(rootNode);
        }
    }
}
