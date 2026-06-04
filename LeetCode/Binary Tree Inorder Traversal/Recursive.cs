using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Tree_Inorder_Traversal
{
    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Traverse(root, result);
            return result;
        }

        private void Traverse(TreeNode node, List<int> result)
        {
            if (node == null) return;

            Traverse(node.left, result);    // go left
            result.Add(node.val);           // process current node
            Traverse(node.right, result);   // go right
        }
    }
}
