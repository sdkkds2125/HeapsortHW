using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HeapsortHW
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node() { }  
        public Node(int data) 
        { 
            Data = data;
            Left = null;
            Right = null;
        }
    }
    internal class HeapSortLL
    {
        private Node current;
        private Node tempHighestForHeapify;
        private int[] nums = new int[20];
        private Random rnd = new Random();
        private int depth;
        public void sortAsLL(Node head) 
        {
            depth = maxDepth(head);
            for (int i = depth;i > 0;i--) 
            {
                checkOfNodesAtXDepth(head,0,i);
            }
            while (head.Right != null && head.Left != null) 
            {
                depth = maxDepth(head);
                Node temp = getAndRemoveNodeAtXDepth(head, 0, depth);
                //swap(head,)
            } 
        }


        public Node generateNumsAndTreeifyThem() {
            for (int i = 0; i < 20; i++) { 
                 nums[i] = rnd.Next(100);            
            }
            Console.WriteLine("the list before sorting");
            for (int i = 0; i < nums.Length; i++) 
            {
                Console.Write(nums[i] + " - ");
            }
            Console.WriteLine("\n");
            Node head = makeNumsIntoTree(nums,0);
            return head;
        }

        public Node makeNumsIntoTree(int[] arr, int i)
        {
            Node root = null;
            // Base case for recursion
            if (i < arr.Length)
            {
                root = new Node(arr[i]);

                // insert left child
                root.Left = makeNumsIntoTree(arr, 2 * i + 1);

                // insert right child
                root.Right = makeNumsIntoTree(arr, 2 * i + 2);
            }
            return root;
        }

        int maxDepth(Node node)
        {
            if (node == null)
                return 0;
            else
            {
                /* compute the depth of each subtree */
                int lDepth = maxDepth(node.Left);
                int rDepth = maxDepth(node.Right);

                /* use the larger one */
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
      
        void checkOfNodesAtXDepth(Node root, int currDepth, int wantedDepth)
        {
            //just in case the level wanted doesn't exist
            if (root == null)
                return;

            // If the wanted level and current level 
            // are same check if node there is heapified
            if (currDepth == wantedDepth)
            {
                heapifyForLL(root);
            } //if greater then done cut it off there like a break
            else if (currDepth > wantedDepth) 
            {
                return;
            }

            // keep going down the left and right subtrees 
            checkOfNodesAtXDepth(root.Left, currDepth + 1,wantedDepth);
            checkOfNodesAtXDepth(root.Right, currDepth + 1, wantedDepth);
        }


        private int getAndRemoveNodeAtXDepth(Node root, int currDepth, int wantedDepth)
        {
            int data;
            if (root == null)
            {
                return -int.MaxValue;
            }
            // If the wanted level and current level 
            // are same delete that node and return its data in a new one
            else if (currDepth == wantedDepth)
            {
                data = root.Data;
                root = null;
                return data;
            }
            
            else
            {
                // keep going down the left and right subtrees 
                getAndRemoveNodeAtXDepth(root.Left, currDepth + 1, wantedDepth);
                getAndRemoveNodeAtXDepth(root.Right, currDepth + 1, wantedDepth);
                return data + 0;
            }
        }

        private void heapifyForLL(Node root)
        {
            tempHighestForHeapify = root;

            if (root != null)
            {
                if (root.Left != null)
                {
                    if (root.Left.Data > tempHighestForHeapify.Data)
                    {
                        tempHighestForHeapify = root.Left;
                    }
                }
                if (root.Right != null)  
                {
                    if(root.Right.Data > tempHighestForHeapify.Data) 
                    {
                        tempHighestForHeapify = root.Right;
                    }
                }
                if(tempHighestForHeapify.Data != root.Data)
                {
                    swap(root, tempHighestForHeapify);
                    heapifyForLL(tempHighestForHeapify);
                }

            }
        }

        private void swap(Node root, Node tempHighestForHeapify)
        {
            int temp = root.Data;
            root.Data = tempHighestForHeapify.Data;
            tempHighestForHeapify.Data = temp;

        }

        public void inOrderPrint(Node root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Data + " ");
                inOrderPrint(root.Left);
                inOrderPrint(root.Right);
            }
        }

   
        public void test()
        {
            Node t2 = new Node();
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
            t2 = makeNumsIntoTree(arr, 0);
            Console.WriteLine(arr.Length);
            Console.WriteLine(maxDepth(t2));
            inOrderPrint(t2);
            Node t3 = new Node(7);
            Node temp = t3;
            temp.Data = 99999999;
            Console.WriteLine(temp.Data);
            Console.WriteLine(t3.Data);
            Console.WriteLine();
            Console.WriteLine();
            Node testHead = new Node(5);
            testHead.Right = new Node(38);
            Node test2 = new Node(46);
            test2.Left = new Node(1);
            test2.Left.Right = new Node(40);
            testHead.Right.Right = new Node(2);
            testHead.Right.Left = new Node(4);
            testHead.Right.Left.Right = new Node(5);
            int depthy = maxDepth(testHead);
            Console.WriteLine("depthy " + depthy);
            //swap(testHead, test2);
            heapifyForLL(testHead);
            inOrderPrint(testHead);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            heapifyForLL(test2);
            inOrderPrint(test2);
        }
    }
}
