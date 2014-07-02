using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class TreeNode<T>
    {
        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }
        public T Value { get; private set; }

        public TreeNode(T data)
        {
            this.Value = data;
        }
    }

}
