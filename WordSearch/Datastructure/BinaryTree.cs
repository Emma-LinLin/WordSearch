namespace WordSearch.Datastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //Binary tree class responsible for inserting root and forwards printing tree function
    internal class BinaryTree
    {
        //First node in the datastructure, the root.
        public TreeNode root;

        /// <summary>
        /// Recursive method responsible for inserting node into datastructure.
        /// </summary>
        /// <param name="value">Repeats of word in file.</param>
        /// <param name="searchWord">Word specified by user.</param>
        /// <param name="fileName">Name of searched file.</param>
        public void Insert(int value, string searchWord, string fileName)
        {
            if (root != null)
            {
                root.Insert(value, searchWord, fileName);
            }
            else
            {
                root = new TreeNode(value, searchWord, fileName);
            }
        }

        /// <summary>
        /// Calls upon the print tree-method inside node class if not empty.
        /// </summary>
        public void PrintTree()
        {
            if (root != null)
            {
                root.PrintTree();
            }
        }
    }
}