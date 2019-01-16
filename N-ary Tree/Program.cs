using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Buid Tree
            Tree<string> boom = new Tree<string>("I ");
            TreeNode<string> Parent;

            // Add Child Nodes to Head of Tree
            boom.AddChildNode(boom.Head, "Am ");
            boom.AddChildNode(boom.Head, "Like ");

            // Parent = first child node of Head of tree
            Parent = boom.Head.ChildNodes[0];
            // Add Child Node to Parent
            boom.AddChildNode(Parent, "Testing ");

            // Parent = second child node of Head of tree
            Parent = boom.Head.ChildNodes[1];
            // Add Child Nodes to Parent
            boom.AddChildNode(Parent, "Fries ");
            boom.AddChildNode(Parent, "Pasta ");
            boom.AddChildNode(Parent, "Pizza ");

            // Draw Tree
            Console.WriteLine("             " + boom.Head.Value);
            foreach (var childNode in boom.Head.ChildNodes)
            {
                Console.Write("     " + childNode.Value.ToString() + "     ");
            }
            Console.WriteLine(" ");
            foreach (var childNode in boom.Head.ChildNodes)
            {
                if (childNode.ChildNodes.Count == 0)
                {
                    Console.Write("     ");
                }
                else
                {
                    foreach (var grandChildNode in childNode.ChildNodes)
                    {
                        Console.Write(grandChildNode.Value.ToString() + " ");
                    }
                    Console.Write("     ");
                }
            }
            
            // Print Information about Tree
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Count: " + boom.Count.ToString());
            Console.WriteLine("LeafCount: " + boom.LeafCount.ToString());
            Console.WriteLine("Sum to leafs: ");
            boom.SumToLeafs().ForEach(i => Console.WriteLine(i.ToString()));
            Console.WriteLine("");
            Console.WriteLine("Values in tree: ");
            foreach (string node in boom)
            {
                Console.WriteLine(node);
            }
            Console.WriteLine("");
            
            // Remove Nodes
            boom.RemoveNode(boom.Head.ChildNodes[1].ChildNodes[0]);
            boom.RemoveNode(boom.Head.ChildNodes[0]);

            Console.WriteLine(Environment.NewLine + "Some values were removed..." + Environment.NewLine);

            // Print Information about Tree    
            Console.WriteLine("Count: " + boom.Count.ToString());
            Console.WriteLine("LeafCount: " + boom.LeafCount.ToString());
            Console.WriteLine("Sum to leafs: ");
            boom.SumToLeafs().ForEach(i => Console.WriteLine(i.ToString()));
            Console.WriteLine("");
            Console.WriteLine("Values in tree: ");
            foreach(string node in boom)
            {
                Console.WriteLine(node);
            }
            
            Console.ReadLine();

        }

    }
}
