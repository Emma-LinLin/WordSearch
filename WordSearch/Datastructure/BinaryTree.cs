namespace WordSearch.Datastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class BinaryTree
    {
        public TreeNode root;

        private TreeNode node = new TreeNode();

        public void Insert(int value, string searchWord, string searchFileName)
        {
            if (root != null)
            {
                root.Insert(value, searchWord, searchFileName);
            }
            else
            {
                root = new TreeNode(value, searchWord, searchFileName);
            }
        }

        public void PrintTree()
        {
            if (root != null)
            {
                root.PrintTree();
            }
        }
    }
}