using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    class Program
    {
        static SingleLinkedList singleLinkedList = null;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of Nodes");
            int numberOfNodes = Convert.ToInt32(Console.ReadLine());

            for (int counter = 1; counter <= numberOfNodes; counter++)
            {
                Console.WriteLine("Enter the data for node {0}",counter);
                int data = Convert.ToInt32(Console.ReadLine());
                if(singleLinkedList == null)
                {
                    singleLinkedList = new SingleLinkedList(data);
                }
                else
                {
                    singleLinkedList.Insert(data);
                }
            }
        }
    }
}
