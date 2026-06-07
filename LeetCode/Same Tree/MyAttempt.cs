using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Same_Tree
{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    //Probably not necessary at the 'best' solution but here we go.
    public int GetTreeHeight(Node root)
    {
        // Base case: an empty tree has a height of 0
        if (root == null)
        {
            return 0;
        }

        // Recursively find the height of left and right subtrees
        int leftHeight = GetTreeHeight(root.Left);
        int rightHeight = GetTreeHeight(root.Right);

        // The height is the greater of the two subtrees + 1 (for the current node)
        return Math.Max(leftHeight, rightHeight) + 1;
    }
    int heightP = GetTreeHeight(TreeNode p);
    int heightQ = GetTreeHeight(TreeNode q);
    if(heightP != heightQ){return false;}

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        //Taking care of the edge cases that I foresee.
        //First, confirm the height is the same
        //If possible, confirm they have the same number of nodes.
        //Return false, if either is false.

        //Traverse thru both trees using two pointer (so we check both at once)
        //Return false at any difference
        //Return true if nothing happens till the end.

        //Or... use the answer from 'Binary Tree Inorder traversal and compare the result arrays...? 
        //sounds inefficient af

    }




}
}
