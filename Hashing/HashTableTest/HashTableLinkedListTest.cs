using System;
using HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzWare.NBuilder;
using System.Collections.Generic;

namespace HashTableUnitTest
{
    [TestClass]
    public class HashTableLinkedListTest
    {
        [TestMethod]
        public void AddHashTableLinkedListTest()
        {
            HashTableLinkedList<string, string> hashTable = new HashTableLinkedList<string, string>(20);
            List<string> randomStrings = new List<string>();
            RandomGenerator ranGen = new RandomGenerator(100);
            for (int i = 0; i < 20; i++)
            {
                randomStrings.Add("EdwinTest" + ranGen.Int());
            }
            foreach (string data in randomStrings)
            {
                hashTable.Add(data, data);
            }


            foreach (string data in randomStrings)
            {
                hashTable.Remove(data);
            }
        }
    }


}
