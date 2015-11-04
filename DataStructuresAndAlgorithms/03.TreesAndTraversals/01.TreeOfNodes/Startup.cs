namespace _01.TreeOfNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static int longestPath;

        public static void Main(string[] args)
        {
            var nodes = ReadInput();

            var root = FindRoot(nodes);

            Console.WriteLine("The root:");
            Console.WriteLine(root.Value);

            var leafs = FindLeafs(nodes);
            Console.WriteLine("Leafs:");
            Console.WriteLine(string.Join(" ", leafs.Select(l => l.Value).ToList()));

            var middleNodes = FindMIddleNodes(nodes);
            Console.WriteLine("MiddleNodes:");
            Console.WriteLine(string.Join(" ", middleNodes.Select(m => m.Value).ToList()));

            FindLongestPath(root, 0);
            Console.WriteLine("The longest path is: {0}", longestPath);
        }

        private static void FindLongestPath(TreeNode<int> node, int path)
        {
            path++;
            foreach (var child in node.Children)
            {
                FindLongestPath(child, path);
            }

            if (path > longestPath)
            {
                longestPath = path;
            }
        }

        private static List<TreeNode<int>> FindMIddleNodes(List<TreeNode<int>> nodes)
        {
            var middleNodes = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.HasParent == true && node.Children.Count != 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<TreeNode<int>> FindLeafs(List<TreeNode<int>> nodes)
        {
            var leafs = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
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
