using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    public class EmptyListException : ApplicationException { }

    public class Tree<T> : IEnumerable<T>
    {
        public TreeNode<T> Head;
        public int Count { get; set; }
        public int LeafCount { get; set; }

        public List<TreeNode<T>> LeafNodes = new List<TreeNode<T>>();

        public Tree(T headValue)
        {
            Head = new TreeNode<T>(headValue, new List<TreeNode<T>>(), null);
            Count = 1;
            LeafCount = 1;
        }

        // Add a childNode to a parentNode
        public void AddChildNode(TreeNode<T> parentNode, T value)
        {
            // Construct new node
            TreeNode<T> ChildNode = new TreeNode<T>(value, new List<TreeNode<T>>(), parentNode);

            // Update leafCount, Count and LeadNodes
            if (parentNode.ChildNodes.Count != 0)
            {
                LeafCount++;
            }
            else
            {
                LeafNodes.Remove(parentNode);
            }
            Count++;
            LeafNodes.Add(ChildNode);

            // Add the childNode to the list of childNodes of the parent
            parentNode.ChildNodes.Add(ChildNode);
        }

        // Remove a given node, and with it all its childNodes
        public void RemoveNode(TreeNode<T> node)
        {
            int nChildNodes = node.ChildNodes.Count;

            // Remove the first childNode [nChildNodes] times (results: no childNodes)
            for (int i = 0; i < nChildNodes; i++)
            {
                RemoveNode(node.ChildNodes[0]);
            }
            
            // Remove node by index
            List<TreeNode<T>> ChildsOfParent = node.ParentNode.ChildNodes;
            int index = ChildsOfParent.FindIndex(a => a.Equals(node));
            ChildsOfParent.Remove(ChildsOfParent[index]);

            // Remove the deleted node from the LeafNodes-list if necessary
            if (LeafNodes.Contains(node))
            {
                LeafNodes.Remove(node);
            }
            
            // Update Count, LeafCount and the list LeafNodes
            Count--;
            if (node.ParentNode.ChildNodes.Count != 0)
            {
                LeafCount--;
            }
            else
            {
                LeafNodes.Add(node.ParentNode);
            }
        } 

        // Save all the sum to the leafs in a list
        public List<T> SumToLeafs()
        {
            List<T> sums = new List<T>();

            // If a node is a LeafNode...
            foreach (var node in LeafNodes)
            {

                TreeNode<T> currentNode = node;
                List<T> sum = new List<T>();                   
                while (currentNode.ParentNode != null)
                {
                    // Add the value of the LeafNode to list "sum"...
                    sum.Add(currentNode.Value);
                    // And "get up" the tree until you reach the head-node
                    currentNode = currentNode.ParentNode;
                }
                sum.Add(Head.Value);

                // Reverse the list in case you're dealing with strings
                sum.Reverse();

                // Add all elements of sum in the variable total
                // total is first set equal to the first element of sum to specify the type
                // the first element of sum is then removed from the list, and all other elements of the list are added to total
                dynamic total = sum[0];
                sum.Remove(sum[0]);
                foreach (var value in sum)
                {
                    total = total + value;
                }

                // The variable total is added to the return-list: sums
                sums.Add(total);
            }
            return sums;
        }

        // Traverse through nodes by using the enumerable properties of the TreeNode-class
        public IEnumerator<T> TraverseNodes()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Head.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Head.GetEnumerator();
        }
    }
}
