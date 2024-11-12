namespace ConsoleApp1;

public static class SortHelper
{
    public static void QuickSort(List<int> arr, int min, int max)
    {
        if (min >= max)
        {
            return;
        }

        var pivot = min - 1;
            
        for (var i = min; i < max; i++)
        {
            if (arr[i] < arr[max])
            {
                pivot++;
                 (arr[pivot], arr[i]) = (arr[i], arr[pivot]);
                
            }
        }

        pivot++;
        (arr[pivot], arr[max]) = (arr[max], arr[pivot]);
            
        QuickSort(arr, min, pivot - 1);
        QuickSort(arr, pivot + 1, max);
    }
    
    public static void InsertionSort(List<int> arr)
    {
        int n = arr.Count;

        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;
            
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }
    
    public static void MergeSort(List<int> arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            
            Merge(arr, left, mid, right);
        }
    }
    
    static void Merge(List<int> arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;
        
        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];
        int i,j;
        
        for (i = 0; i < n1; ++i)
            leftArray[i] = arr[left + i];
        for (j = 0; j < n2; ++j)
            rightArray[j] = arr[mid + 1 + j];
        

        i = 0;
        j = 0;
        
        int k = left;
        while (i < n1 && j < n2)
        {
            if (leftArray[i] <= rightArray[j])
            {
                arr[k] = leftArray[i];
                i++;
            }
            else
            {
                arr[k] = rightArray[j];
                j++;
            }
            k++;
        }
        
        while (i < n1)
        {
            arr[k] = leftArray[i];
            i++;
            k++;
        }
        
        while (j < n2)
        {
            arr[k] = rightArray[j];
            j++;
            k++;
        }
    }
}