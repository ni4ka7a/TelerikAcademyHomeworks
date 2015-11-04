namespace _01.TreeOfNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var tree = ReadInput();

            var root = FindRoot(tree);
            Console.WriteLine(root.Value);

            PrintTree(root);
        }

        private static void PrintTree(TreeNode<int> tree)
        {
            foreach (var item in tree.Children)
            {
                Console.WriteLine(item.Value);

                PrintTree(item);
            }
        }

        private static TreeNode<int> FindRoot(List<TreeNode<int>> nodes)
        {
            foreach (var node in nodes)
            {
                if (node.HasParent == false)
                {
                    return node;
                }
            }

            return null;
        }

        private static List<TreeNode<int>> ReadInput()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            var nodes = new List<TreeNode<int>>();

            for (int i = 0; i < nodesCount - 1; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                var parantValue = int.Parse(line[0]);
                var childValue = int.Parse(line[1]);

                var parent = nodes.FirstOrDefault(node => parantValue == node.Value);
                if (parent == null)
                {
                    parent = new TreeNode<int>(parantValue);
                    nodes.Add(parent);
                }

                var child = nodes.FirstOrDefault(node => childValue == node.Value);
                if (child == null)
                {
                    child = new TreeNode<int>(childValue);
                    nodes.Add(child);
                }

                parent.AddChild(child);
            }

            return nodes;
        }
    }
}
