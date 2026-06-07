using System;
using System.Collections.Generic;
using System.Text;

namespace Same_Tree
{
    internal class Solution
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            // Both null → same
            if (p == null && q == null) return true;
            // One null, one not → different
            if (p == null || q == null) return false;
            // Values differ → different
            if (p.val != q.val) return false;
            // Recurse on both subtrees
            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
