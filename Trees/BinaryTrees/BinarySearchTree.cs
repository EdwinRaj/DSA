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
                    if (IsLessThanOrEqualTo(data,currentNode.Value))
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
            valueQueue.ToList().ForEach(x=>Console.Write(x));

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

        #region Privates
        private bool IsLessThanOrEqualTo<T>(T data,T currentNodeValue)
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
