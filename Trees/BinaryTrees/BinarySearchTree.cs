using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinarySearchTree<T>
    {
        private TreeNode<T> _rootNode;

        public BinarySearchTree()
        {

        }

        public TreeNode<T> RootNode
        {
            get
            {
                return _rootNode;
            }
        }

        public void Insert(T data)
        {
            if (_rootNode == null)
            {
                _rootNode = new TreeNode<T>(data);
            }
            else
            {
                TreeNode<T> currentNode = _rootNode;
                Stack<TreeNode<T>> localStack = new Stack<TreeNode<T>>();
                while (true)
                {
                    if (IsLessThanOrEqualTo(data, currentNode.Value))
                    {
                        if (currentNode.LeftNode == null)
                        {
                            currentNode.LeftNode = new TreeNode<T>(data);
                            break;
                        }
                        else
                            currentNode = currentNode.LeftNode;
                    }

                    if (IsGreaterThan(data, currentNode.Value))
                    {
                        if (currentNode.RightNode == null)
                        {
                            currentNode.RightNode = new TreeNode<T>(data);
                            break;
                        }
                        else
                            currentNode = currentNode.RightNode;
                    }

                }
            }
        }

        public bool Lookup(T data)
        {
            bool isValid = false;

            if (_rootNode == null)
                return isValid;

            TreeNode<T> currentNode = _rootNode;

            while (true)
            {
                if (IsEqual(data, currentNode.Value))
                {
                    isValid = true;
                    break;
                }
                else
                {
                    if (IsLessThanOrEqualTo(data, currentNode.Value))
                    {
                        currentNode = currentNode.LeftNode;
                    }
                    else
                    {
                        currentNode = currentNode.RightNode;
                    }
                    if (currentNode == null)
                        break;
                }
            }


            return isValid;
        }

        public void PrintTree()
        {
            Queue<T> valueQueue = new Queue<T>();
            Queue<TreeNode<T>> nodeQueue = new Queue<TreeNode<T>>();

            TreeNode<T> currentNode = _rootNode;
            while (true)
            {
                valueQueue.Enqueue(currentNode.Value);

                if (currentNode.LeftNode != null)
                {
                    //valueQueue.Enqueue(currentNode.LeftNode.Value);
                    nodeQueue.Enqueue(currentNode.LeftNode);
                }

                if (currentNode.RightNode != null)
                {
                    //valueQueue.Enqueue(currentNode.RightNode.Value);
                    nodeQueue.Enqueue(currentNode.RightNode);
                }

                if (nodeQueue.Count == 0)
                    break;

                currentNode = nodeQueue.Dequeue();

            }
            valueQueue.ToList().ForEach(x => Console.Write(x));

        }

        public int Size(TreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return Size(node.LeftNode) + 1 + Size(node.RightNode);
            }
        }

        public int MaxDepth(TreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftTreeDepth = MaxDepth(node.LeftNode);
                int rightTreeDepth = MaxDepth(node.RightNode);
                if (leftTreeDepth > rightTreeDepth)
                {
                    return leftTreeDepth + 1;
                }
                else
                {
                    return rightTreeDepth + 1;
                }
            }
        }

        public T MaxValue(TreeNode<T> node)
        {
            if (node == null)
                return default(T);
            else if (node.RightNode == null)
            {
                return node.Value;
            }
            else
            {
                return MaxValue(node.RightNode);
            }
        }

        /// <summary>
        /// Inorder Traversal of tree prints the numbers in ascending order
        ///              4
        ///           /     \
        ///          2       5 
        ///         / \
        ///        1   3
        /// Result: 1,2,3,4,5
        /// </summary>
        /// <param name="node"></param>
        public void InOrderTraversalPrint(TreeNode<T> node)
        {
            if (node == null)
                return;

            InOrderTraversalPrint(node.LeftNode);
            Console.Write(node.Value + ", ");
            InOrderTraversalPrint(node.RightNode);
        }

        /// <summary>
        /// Inorder Traversal of tree prints the numbers in ascending order
        ///              4
        ///           /     \
        ///          2       5 
        ///         / \
        ///        1   3
        /// Result: 4,2,1,3,5
        /// The sequence is as follows
        /// visit Node
        /// preorder(left_child)
        /// preorder(right_child)
        /// </summary>
        /// <param name="node"></param>
        public void PreOrderTraversalPrint(TreeNode<T> node)
        {
            if (node == null)
                return;

            Console.Write(node.Value + ", ");
            PreOrderTraversalPrint(node.LeftNode);
            PreOrderTraversalPrint(node.RightNode);
        }

        /// <summary>
        /// PostOrder Traversal of tree: traverse left, traverse right, visit
        ///              4
        ///           /     \
        ///          2       5 
        ///         / \
        ///        1   3
        /// Result: 1,3,2,5,4
        /// Bottom up Traversal
        /// </summary>
        /// <param name="node"></param>
        public void PostOrderTraversalPrint(TreeNode<T> node)
        {
            if (node == null)
                return;

            PostOrderTraversalPrint(node.LeftNode);
            PostOrderTraversalPrint(node.RightNode);
            Console.Write(node.Value + ", ");
        }


        Queue<TreeNode<T>> levelOrderTraversalQueue = new Queue<TreeNode<T>>();
        /// <summary>
        /// Level Order Traversal:Visits the tree level by level
        ///              4
        ///           /     \
        ///          2       5 
        ///         / \
        ///        1   3
        /// Result: 4,2,5,1,3
        /// TopDown Traversal
        /// </summary>
        /// <param name="node"></param>
        public void LevelOrderTraversalTopDownPrint(TreeNode<T> node)
        {
            if (node == null)
                return;

            levelOrderTraversalQueue.Enqueue(node);

            while (levelOrderTraversalQueue.Count != 0)
            {
                TreeNode<T> currentNode = levelOrderTraversalQueue.Dequeue();
                Console.Write(currentNode.Value);

                if (currentNode.LeftNode != null)
                    levelOrderTraversalQueue.Enqueue(currentNode.LeftNode);

                if (currentNode.RightNode != null)
                    levelOrderTraversalQueue.Enqueue(currentNode.RightNode);
            }

        }


        Queue<TreeNode<T>> levelTraversalBottomUpQueue = new Queue<TreeNode<T>>();
        Stack<TreeNode<T>> levelTraversalBottomUpStack = new Stack<TreeNode<T>>();
        /// <summary>
        /// Level Order Traversal:Visits the tree level by level
        ///              4
        ///           /     \
        ///          2       5 
        ///         / \
        ///        1   3
        /// Result: 1,3,2,5,4
        /// Bottom up Traversal
        /// </summary>
        /// <param name="node"></param>
        public void LevelOrderTraversalBottomUpPrint(TreeNode<T> node)
        {
            if (node == null)
                return;

            levelTraversalBottomUpQueue.Enqueue(node);

            while (levelTraversalBottomUpQueue.Count != 0)
            {
                TreeNode<T> currentNode = levelTraversalBottomUpQueue.Dequeue();
                levelTraversalBottomUpStack.Push(currentNode);

                if (currentNode.RightNode != null)//changed the order
                    levelTraversalBottomUpQueue.Enqueue(currentNode.RightNode);

                if (currentNode.LeftNode != null)//changed the order
                    levelTraversalBottomUpQueue.Enqueue(currentNode.LeftNode);
            }

            while (levelTraversalBottomUpStack.Count != 0)
            {
                Console.Write(levelTraversalBottomUpStack.Pop().Value);
            }
        }


        Stack<int> hasPathSumStack = new Stack<int>();
        /// <summary>
        /// If the path from root to leaf, matches the input sum
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode<int> node, int sum)
        {
            //The idea is to do preorder traversal and save the values in the stack
            if (node == null)
                return (sum == 0);
            else
            {
                sum = sum - node.Value;
                return (HasPathSum(node.LeftNode, sum) || HasPathSum(node.RightNode, sum));
            }
        }

        List<T> rootToLeafList = new List<T>(); 
        /* 
         Given a binary tree, print out all of its root-to-leaf 
         paths, one per line. Uses a recursive helper to do the work. 
        */
        public void PrintAllRootToLeafPath(TreeNode<T> node)
        {
            //if (node!= null && (node.LeftNode == null && node.RightNode == null))
            //{
            //    rootToLeafList.Add(node.Value);
            //    Console.WriteLine(string.Join(",", rootToLeafList.ToArray()));
            //    rootToLeafList.Remove(node.Value);
            //}
            //else
            //{
            //    rootToLeafList.Add(node.Value);
            //    PrintAllRootToLeafPath(node.LeftNode);
            //    PrintAllRootToLeafPath(node.RightNode);
            //}

            PrintAllRootToLeafPathHelper(node, new List<T>());
        }

        private void PrintAllRootToLeafPathHelper(TreeNode<T> node, List<T> path)
        {
            if (node == null)
                return;

            path.Add(node.Value);

            if (node.LeftNode == null && node.RightNode == null)
            {
                Console.WriteLine(string.Join(",", path.ToArray()));
                path.Remove(node.Value);
            }
            PrintAllRootToLeafPathHelper(node.LeftNode, path);
            PrintAllRootToLeafPathHelper(node.RightNode, path);
            path.Remove(node.Value);
        }

        #region Privates
        private bool IsLessThanOrEqualTo<T>(T data, T currentNodeValue)
        {
            return Comparer<T>.Default.Compare(data, currentNodeValue) <= 0;
        }

        private bool IsGreaterThan<T>(T data, T currentNodeValue)
        {
            return Comparer<T>.Default.Compare(data, currentNodeValue) > 0;
        }

        private bool IsEqual<T>(T data, T currentNodeValue)
        {
            return Comparer<T>.Default.Compare(data, currentNodeValue) == 0;
        }

        #endregion Privates


    }
}
