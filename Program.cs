

using HeapsortHW;

public class HeapSortArr
{
    public static void sortAsArray(int[] arr)
    {
        int length = arr.Length;

        // Build max heap 
        for (int i = length / 2 - 1; i >= 0; i--)
        {
            heapifyAsArray(arr, length, i);
        }
        // One by one extract an element from heap
        for (int i = length - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // call max heapify on the reduced heap
            heapifyAsArray(arr, i, 0);
        }
    }

    
    static void heapifyAsArray(int[] arr, int length, int i)
    {
        int largest = i; // root
        int leftChild = 2 * i + 1; // left 
        int rightChild = 2 * i + 2; // right

        // If left child is larger than root
        if (leftChild < length && arr[leftChild] > arr[largest])
            largest = leftChild;

        // If right child is larger than largest so far (either root or left)
        if (rightChild < length && arr[rightChild] > arr[largest])
            largest = rightChild;

        // If largest was changed so is no longer ponting to the root
        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;

            // Recursively heapify the affected sub-tree
            //since now I have done a switch make sure that the rest is still hepified all the way down
            heapifyAsArray(arr, length, largest);
        }
    }

    // A utility function to print array
    public static void printArray(int[] arr)
    {

        for (int i = 0; i < arr.Length; ++i)
        {
            Console.Write(arr[i] + " ");
        }
    }


}




class Program
{
    static int Nodes;
    static Node First, Current;

    public static void Run2()
    {
        int i, j;
        int[] dataList = { 3, 5, 67, 43, 52, 11, 23, 4, 8, 54, 32, 76, 39, 23 };

        foreach (int num in dataList)
        {

            Current = new Node();
            Current.Data = num;
            Nodes++;
           
            //
            for (i = Nodes, j = -1; i > 0; i >>= 1, j++) ;

            if (First == null)
            {
                First = Current;
                First.Left = null;
                First.Right = null;
            }
            else
                AddNode(First, First, j - 1);

        }



        while (Nodes > 0)
        {
            Console.Write($"{First.Data} -> ");
            for (i = Nodes, j = -1; i > 0; i >>= 1, j++) ;
            GetRoot(First, j - 1);
            Nodes--;
            HeapSort(First);
        }

        Console.WriteLine("\n\n");
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void AddNode(Node tmp1, Node parent, int pos)
    {
        int dirxn = GetBit(Nodes, pos);

        if (pos == 0)
        {
            if (dirxn == 1)
                tmp1.Right = Current;
            else
                tmp1.Left = Current;

            Current.Left = null;
            Current.Right = null;

            if (Current.Data > tmp1.Data)
                Swap(ref Current.Data, ref tmp1.Data);
        }
        else
        {
            if (dirxn == 1)
                AddNode(tmp1.Right, tmp1, pos - 1);
            else
                AddNode(tmp1.Left, tmp1, pos - 1);
        }

        if (tmp1.Data > parent.Data)
            Swap(ref parent.Data, ref tmp1.Data);
    }

    static void GetRoot(Node tmp, int pos)
    {
        int dirxn;

        if (Nodes == 1)
            return;

        while (pos > 0)
        {
            dirxn = GetBit(Nodes, pos);

            if (dirxn == 1)
                tmp = tmp.Right;
            else
                tmp = tmp.Left;

            pos--;
        }

        dirxn = GetBit(Nodes, pos);

        if (dirxn == 1)
        {
            First.Data = tmp.Right.Data;
            tmp.Right = null;
        }
        else
        {
            First.Data = tmp.Left.Data;
            tmp.Left = null;
        }
    }

    static void HeapSort(Node tmp)
    {
        if (tmp.Right == null && tmp.Left == null)
            return;

        if (tmp.Right == null)
        {
            if (tmp.Left.Data > tmp.Data)
                Swap(ref tmp.Left.Data, ref tmp.Data);
        }
        else
        {
            if (tmp.Right.Data > tmp.Left.Data)
            {
                if (tmp.Right.Data > tmp.Data)
                {
                    Swap(ref tmp.Right.Data, ref tmp.Data);
                    HeapSort(tmp.Right);
                }
            }
            else
            {
                if (tmp.Left.Data > tmp.Data)
                {
                    Swap(ref tmp.Left.Data, ref tmp.Data);
                    HeapSort(tmp.Left);
                }
            }
        }
    }

    static int GetBit(int num, int pos)
    {
        return (num & (1 << pos)) == 0 ? 0 : 1;
    }
}



namespace yy {
    class fert2 {
        public static void Main(string[] args)
        {
            int[] arr = { 4, 10,46,0,67, 3,6,89,4,6,98,65,23,12,28,45 };
            Console.WriteLine("Original array:");
            HeapSortArr.printArray(arr);

            HeapSortArr.sortAsArray(arr);

            Console.WriteLine("\nSorted");
            HeapSortArr.printArray(arr);
            Console.WriteLine("\n\n");
            //Program.Run2();
            HeapSortLL heapSortLL = new HeapSortLL();
            heapSortLL.generateNumsAndTreeifyThem();
            heapSortLL.test();
        }
    }
}
