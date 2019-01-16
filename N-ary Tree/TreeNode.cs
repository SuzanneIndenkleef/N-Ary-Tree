using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    public class TreeNode<T>:IEnumerable<T>
    {
        public T Value { get; set; }
        public List<TreeNode<T>> ChildNodes;
        public TreeNode<T> ParentNode { get; set; }

        // Constructor
        public TreeNode(T value, List<TreeNode<T>> childNodes, TreeNode<T> parentNode)
        {
            this.Value = value;
            this.ChildNodes = childNodes;
            this.ParentNode = parentNode;           
        }

        // Create the enumerator for TreeNode
        private IEnumerator<T> CreateEnumerator()
        {
            yield return Value;
            foreach (TreeNode<T> child in ChildNodes)
            {
                foreach (T value in child)
                {
                    yield return value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return CreateEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CreateEnumerator();
        }
    }
}
