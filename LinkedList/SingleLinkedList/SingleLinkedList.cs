using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class SingleLinkedList
    {
        public Node Start { get; set; }

        public Node Last { get; set; }

        public SingleLinkedList(int data)
        {
            var startNode = new Node(data);
            Start = startNode;
            Last = startNode;
        }

        public void Insert(int data)
        {
            var node = new Node(data);
            Last.Next = node;
            Last = node;
        }



    }
}
