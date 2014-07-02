using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinarySearchTree<T> 
    {
        private TreeNode<T> RootNode;

        public BinarySearchTree()
        {

        }

        public void Insert(T data)
        {
            if (RootNode == null)
            {
                RootNode = new TreeNode<T>(data);
            }
            else
            {
                TreeNode<T> currentNode = RootNode;
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

        #region Privates
        private bool IsLessThanOrEqualTo<T>(T data,T currentNodeValue)
        {
            return Comparer<T>.Default.Compare(data, currentNodeValue) <= 0;
        }

        private bool IsGreaterThan<T>(T data, T currentNodeValue)
        {
            return Comparer<T>.Default.Compare(data, currentNodeValue) > 0;
        }

        #endregion Privates

        public void PrintTree()
        {
 
        }
    }
}
