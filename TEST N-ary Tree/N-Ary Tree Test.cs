using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_ary_Tree
{
    [TestFixture]
    class N_Ary_Tree_Test
    {
        // Test the AddChildNode-method
        [TestCase]
        public void Test_Tree_AddChildNode()
        {
            // Arrange
            Tree<int> IntTree = new Tree<int>(2);
            Tree<string> StringTree = new Tree<string>("Test");

            // Act
            IntTree.AddChildNode(IntTree.Head, 5);
            StringTree.AddChildNode(StringTree.Head, "123");
            StringTree.AddChildNode(StringTree.Head, "321");
            StringTree.AddChildNode(StringTree.Head.ChildNodes[0], "456");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(IntTree.Head.ChildNodes[0].Value == 5);
                Assert.That(StringTree.Head.ChildNodes[0].ChildNodes[0].ParentNode.Value == "123");
                Assert.That(StringTree.Count == 4 && StringTree.LeafCount == 2);
            });
        }

        // Test the DeleteNode-method
        [TestCase]
        public void Test_Tree_DeleteNode()
        {
            // Arrange
            Tree<double> DoubleTree = new Tree<double>(1.45);
            DoubleTree.AddChildNode(DoubleTree.Head, 16.23);
            DoubleTree.AddChildNode(DoubleTree.Head, 7.44);
            DoubleTree.AddChildNode(DoubleTree.Head.ChildNodes[0], 3.21);

            // Act
            DoubleTree.RemoveNode(DoubleTree.Head.ChildNodes[0]);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(DoubleTree.LeafCount == 1);
                Assert.That(DoubleTree.Count == 2);
                Assert.That(DoubleTree.Head.ChildNodes[0].Value == 7.44);
            });
        }

        // Test if the N-ary Tree is enumerable
        [TestCase]
        public void Test_Tree_TraverseNodes()
        {
            // Arrange
            Tree<int> IntTree = new Tree<int>(1);
            IntTree.AddChildNode(IntTree.Head, 2);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[0], 3);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[0], 4);
            IntTree.AddChildNode(IntTree.Head, 5);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[1], 6);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[1].ChildNodes[0], 7);

            // Act
            List<int> AllValues = IntTree.ToList();
            List<int> CheckList = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7
            };

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(AllValues.All(CheckList.Contains));
                Assert.That(AllValues.Count == IntTree.Count);
            });
        }

        // Test the SumToLeafs-method
        [TestCase]
        public void Test_Tree_SumToLeafs()
        {
            // Arrange
            Tree<int> IntTree = new Tree<int>(1);
            IntTree.AddChildNode(IntTree.Head, 2);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[0], 3);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[0], 4);
            IntTree.AddChildNode(IntTree.Head, 5);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[1], 6);
            IntTree.AddChildNode(IntTree.Head.ChildNodes[1].ChildNodes[0], 7);

            List<int> IntCheckList = new List<int>{
                6, 7, 19 };

            Tree<string> StringTree = new Tree<string>("Test");
            StringTree.AddChildNode(StringTree.Head, "123");
            StringTree.AddChildNode(StringTree.Head, "321");
            StringTree.AddChildNode(StringTree.Head.ChildNodes[0], "456");

            List<string> StringCheckList = new List<string>
            {
                "Test123456", "Test321"
            };

            // Act
            List<int> IntSumToLeafs = IntTree.SumToLeafs();
            List<string> StringSumToLeafs = StringTree.SumToLeafs();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(IntSumToLeafs.All(IntCheckList.Contains));
                Assert.That(IntSumToLeafs.Count == IntTree.LeafCount);
                Assert.That(StringSumToLeafs.All(StringCheckList.Contains));
                Assert.That(StringSumToLeafs.Count == StringTree.LeafCount);
            });

        }
        

    }
}
