using BTSexam.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BTSexam.Models
{
    internal class TreeNode
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public TreeNode Right { get; set; } = null;
        public TreeNode Left { get; set; } = null;
        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity}], " +
                $"Defenses: " + string.Join(", ", Defenses);
        }

    }
    internal class BinaryTreeSearch
    {
        public TreeNode root { get; set; } = null!;

        public void Insert(TreeNode treeNode)
        {
            root = InsertRecursive(root, treeNode);
        }

        private TreeNode? InsertRecursive(TreeNode? node, TreeNode InsertedNode)
        {
            if (node == null)
            {
                return InsertedNode;
            }

            if (InsertedNode.MinSeverity == node.MinSeverity)
            {
                node.Right = InsertRecursive(node.Right, InsertedNode);
            }

            if (InsertedNode.MaxSeverity < node.MinSeverity)
            {
                node.Left = InsertRecursive(node.Left, InsertedNode);
            }

            else
            {
                node.Right = InsertRecursive(node.Right, InsertedNode);
            }


            return node;
        }

        public void PreOrderTraversal(TreeNode root, string direction = "Root: ", int depth = 0)
        {
            if (root == null) return;

            string spaces = "- ".Repeat(depth) + ">";
            Console.WriteLine(spaces + direction + root.ToString() + "\n"); // process the root
            PreOrderTraversal(root.Left, "Left: ", depth + 1);// process the left
            PreOrderTraversal(root.Right, "Right: ", depth + 1);// process the right
        }

        public TreeNode? PreOrderSearch(int threatSeverity, TreeNode root)
        {
            if (root == null) { return null; }

            if (threatSeverity >= root.MinSeverity && threatSeverity <= root.MaxSeverity)
                return root;

            TreeNode? treeNode = PreOrderSearch(threatSeverity, root.Left);
            if (treeNode == null)
            {
                treeNode = PreOrderSearch(threatSeverity, root.Right);
            }

            return treeNode;
        }

        private List<TreeNode> getAllTreeNodes(TreeNode? root)
        {
            if (root == null) { return []; }

            var currentNodeList = new List<TreeNode> { root };

            var leftSubtreeList = treeNodes(root.Left);

            var rightSubtreeList = treeNodes(root.Right);

            return [.. currentNodeList, .. leftSubtreeList, .. rightSubtreeList];
        }

    



    }
}
