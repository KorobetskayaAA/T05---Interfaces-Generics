using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericTree
{
    class TreeNode<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> Children { get; }

        public TreeNode(T value)
        {
            Value = value;
            Children = new List<TreeNode<T>>();
        }

        public TreeNode(T value, List<TreeNode<T>> children)
        {
            Value = value;
            Children = children;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(Value.ToString());
            foreach (var child in Children)
            {
                foreach (string line in child.ToString().Split(Environment.NewLine))
                {
                    sb.Append(Environment.NewLine);
                    sb.Append("  ");
                    sb.Append(line);
                }
            }
            return sb.ToString();
        }
    }

    class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        public Tree(T rootValue)
        {
            Root = new TreeNode<T>(rootValue);
        }

        public override string ToString()
        {
            return Root.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree<string> foodTree = new Tree<string>("Продукты");
            foodTree.Root.Children.Add(
                new TreeNode<string>("Хлеб")
            );
            foodTree.Root.Children.Add(
                new TreeNode<string>("Овощи",
                    new List<TreeNode<string>>()
                    {
                        new TreeNode<string>("Капуста"),
                        new TreeNode<string>("Томаты",
                            new List<TreeNode<string>>()
                            {
                                new TreeNode<string>("Черри"),
                                new TreeNode<string>("Сливовидные")
                            }
                        ),
                        new TreeNode<string>("Огурцы"),
                    }
                )
            );
            foodTree.Root.Children.Add(
                new TreeNode<string>("Молочные продукты",
                    new List<TreeNode<string>>()
                    {
                        new TreeNode<string>("Молоко"),
                        new TreeNode<string>("Кефир"),
                        new TreeNode<string>("Сметана"),
                        new TreeNode<string>("Творог"),
                        new TreeNode<string>("Йогурт"),
                    }
                )
            );

            Console.WriteLine(foodTree);
        }
    }
}
