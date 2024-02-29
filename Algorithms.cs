public class Algorithms
{	
	public void sortList(List<Word> words)
	{
		mergeSort(words, 0, words.Count - 1);
	}
	
	public int indexList(string word, List<Word> words)
	{
		int middle = (0 + words.Count - 1) / 2;
		if(String.Compare(words[middle].Name, word) == 0)
			return middle;
		else if(middle == words.Count)
		{
			return -1;
		}
		else if(String.Compare(words[middle].Name, word) < 0) //in the second half
		{
			int n = middle - 0 + 1;
			List<Word> rightArray = new List<Word>();
			for (int i = 0; i < n; i++)
			{
				rightArray.Add(arr[0 + i]);
			}
			return indexList(word, rightArray);
		}
		else //in first half
		{
			List<Word> leftArray = new List<Word>();
			int n = words.Count - 1 - middle;
			List<Word> leftArray = new List<Word>();
			for (int i = 0; i < n; i++)
			{
				leftArray.Add(arr[middle + i]);
			}
			return indexList(word, leftArray);
		}
			
		return -1;
	}

	public bool duplicates(string word, List<Word> word)
	{
		
	}
	
	public void insertList(Word word, List<Word> words)
	{
		
	}
	
	public void merge(List<> arr, int left, int middle, int right) 
	{
		int n1 = middle - left + 1;
        int n2 = right - middle;

        List<Word> leftArray = new List<Word>(); //leftside of list
        List<Word> rightArray = new List<Word>();//rightside of list

		//splits both sides
        for (int i = 0; i < n1; i++)
        {
            leftArray.Add(arr[left + i]);
        }

        for (int j = 0; j < n2; j++)
        {
            rightArray.Add(arr[middle + 1 + j]);
        }

		//keeping track of our position
        int index1 = 0;
        int index2 = 0;
        int k = left;

        while (index1 < n1 && index2 < n2)
        {
            if (String.Compare(leftArray[index1].Name, rightArray[index2].Name) <= 0) //We are comparing the names of the word, not the word themselves
            {
                arr[k] = leftArray[index1];
                index1++;
            }
            else
            {
                arr[k] = rightArray[index2];
                index2++;
            }
            k++;
        }

		//combining each side of the list back into the original array
        while (index1 < n1)
        {
            arr[k] = leftArray[index1];
            index1++;
            k++;
        }

        while (index2 < n2)
        {
            arr[k] = rightArray[index2];
            index2++;
            k++;
        }
	}

	public void mergeSort(List<Word> arr, int left, int right) 
	{
	    if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
	}
}