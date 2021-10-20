namespace WordSearch.Datastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class TreeNode
    {
        public int data { get; set; }

        public string word { get; set; }

        public string fileName { get; set; }

        public TreeNode rightNode { get; set; }

        public TreeNode leftNode { get; set; }

        public TreeNode()
        {
        }

        public TreeNode(int value, string searchWord, string searchFileName)
        {
            data = value;
            word = searchWord;
            fileName = searchFileName;
        }

        public void Insert(int value, string searchWord, string searchFileName)
        {
            if (value >= data)
            {
                if (rightNode == null)
                {
                    rightNode = new TreeNode(value, searchWord, searchFileName);
                }
                else
                {
                    rightNode.Insert(value, searchWord, searchFileName);
                }
            }
            else
            {
                if (leftNode == null)
                {
                    leftNode = new TreeNode(value, searchWord, searchFileName);
                }
                else
                {
                    leftNode.Insert(value, searchWord, searchFileName);
                }
            }
        }

        public void PrintTree()
        {
            Console.WriteLine($"Filename: {fileName}. Word: {word}. Amount of times in document: {data}");

            if (leftNode != null)
            {
                leftNode.PrintTree();
            }
            if (rightNode != null)
            {
                rightNode.PrintTree();
            }
        }
    }
}