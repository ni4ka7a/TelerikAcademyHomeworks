namespace _01.TreeOfNodes
{
    using System;
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        private T value;
        private List<TreeNode<T>> children;

        public TreeNode()
        {
            this.children = new List<TreeNode<T>>();
        }

        public TreeNode(T value)
            : this()
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            this.Value = value;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public bool HasParent { get; set; }

        public List<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }

            if (child.HasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }

            child.HasParent = true;
            this.children.Add(child);
        }
    }
}
