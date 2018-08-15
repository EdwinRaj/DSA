using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class Node
    {
        public int Data { get; private set; }
        public Node Next { get; set; }

        public Node(int i)
        {
            Data = i;
            Next = null;
        }
    }
}
