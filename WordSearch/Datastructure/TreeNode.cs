namespace WordSearch.Datastructure
{
    using System;

    /// <summary>
    /// Node class responsible for insert and print data structure
    /// </summary>
    internal class TreeNode
    {
        //The number of repeats in current node
        public int data { get; set; }

        //Search word of current node
        public string word { get; set; }

        //Filename for current node
        public string fileName { get; set; }

        //The node to the right from current node(higher)
        public TreeNode rightNode { get; set; }

        //The node to the left of current node(lower)
        public TreeNode leftNode { get; set; }

        public TreeNode()
        {
        }

        /// <summary>
        /// Constructor for new tree node
        /// </summary>
        /// <param name="value">repeats</param>
        /// <param name="searchWord">search word</param>
        /// <param name="searchFileName">file name</param>
        public TreeNode(int value, string searchWord, string searchFileName)
        {
            data = value;
            word = searchWord;
            fileName = searchFileName;
        }

        /// <summary>
        /// Inserts a new node if the node is not null recursively, if the node is null a new node will be created
        /// Time complexity O(1) + O(1) + O(log n) = O(log n + 2)
        /// Asymptotisk analys O(log n)
        /// Recursion is used in order to break down the problem and get further and further for each iteration towards the result sought after.
        /// </summary>
        /// <param name="value">repeats</param>
        /// <param name="searchWord">search word</param>
        /// <param name="searchFileName">file name</param>
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

        /// <summary>
        /// Prints the whole data structure recursively in pre order traversal order.
        /// </summary>
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