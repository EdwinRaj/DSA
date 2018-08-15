using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class UdemyBinaryTrees
    {
        public TreeNode CreateTree()
        {
            var tNode = new TreeNode('T');
            var qNode = new TreeNode('Q');
            var sNode = new TreeNode('S',tNode,qNode);

            var dNode = new TreeNode('D');
            var eNode = new TreeNode('E', null, right: dNode);

            var aNode = new TreeNode('A',sNode,eNode);

            var cNode = new TreeNode('C');
            var fNode = new TreeNode('F');
            var rNode = new TreeNode('R',cNode,fNode);

            var mNode = new TreeNode('M');
            var xNode = new TreeNode('X', mNode, rNode);
            
            var pNode = new TreeNode('P',aNode,xNode);

            return pNode;

        }

        /// <summary>
        /// Result: PASTQEDXMRCF
        /// </summary>
        /// <param name="rootNode"></param>
        public void PreOrderTraversal(TreeNode rootNode)
        {
            if (rootNode == null)
                return;

            Console.Write(rootNode.Info);
            PreOrderTraversal(rootNode.LeftNode);
            PreOrderTraversal(rootNode.RightNode);
        }

        /// <summary>
        /// Result: TSQAEDPMXCRF
        /// </summary>
        /// <param name="rootNode"></param>
        public void InOrderTraversal(TreeNode rootNode)
        {
            if (rootNode == null)
                return;

            InOrderTraversal(rootNode.LeftNode);
            Console.Write(rootNode.Info);
            InOrderTraversal(rootNode.RightNode);
        }

        /// <summary>
        /// Result: TQSDEAMCFRXP
        /// </summary>
        /// <param name="rootNode"></param>
        public void PostOrderTraversal(TreeNode rootNode)
        {
            if (rootNode == null)
                return;

            PostOrderTraversal(rootNode.LeftNode);
            PostOrderTraversal(rootNode.RightNode);
            Console.Write(rootNode.Info);
        }


        /// <summary>
        /// Algo
        /// 1. Insert root node into Q
        /// 2. Dequeu the first node from queue
        /// 3. Visit left.
        /// 4. Visit Right
        /// 5. Enqueue left
        /// 6. Enqueu Right
        /// 7. Goto step 2 until all nodes are exhausted
        /// </summary>
        /// <param name="node"></param>
        public void LevelOrderTraversal(TreeNode node)
        {
            Queue<TreeNode> localQueue = new Queue<TreeNode>();
            localQueue.Enqueue(node);

            while(localQueue.Count() != 0)
            {
                var currentNode = localQueue.Dequeue();
                Console.WriteLine(currentNode.Info);
                if (currentNode.LeftNode != null)
                    localQueue.Enqueue(currentNode.LeftNode);

                if (currentNode.RightNode != null)
                    localQueue.Enqueue(currentNode.RightNode);
            }
        }
    }

    public class TreeNode
    {
        public TreeNode LeftNode { get; set; }
        public TreeNode RightNode { get; set; }

        public char Info { get; set; }

        public TreeNode(char info,TreeNode left = null,TreeNode right = null)
        {
            Info = info;
            LeftNode = left;
            RightNode = right;
        }

    }
}
