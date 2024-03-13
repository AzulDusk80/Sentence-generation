using System.Collections.Generic;

public class Algorithms
{	
	public void sortList(List<Word> words)
	{
		mergeSort(words, 0, words.Count - 1);   //merge sort based on Name
	}
	
	public int indexList(string word, List<Word> words) //binary searches to determine if it is in the list based on Name
	{
        int min = 0;
        int max = words.Count - 1;

		while (min <= max)
		{
			int middle = min + (max - min) / 2; //to move the we minus max with min, otherwise it will loop forever if found in the second half
			if (String.Compare(words[middle].Name, word) == 0) //It has been found
				return middle;
			else if (String.Compare(words[middle].Name, word) < 0) //in the second half
			{
				min = middle + 1;
			}
			else //in first half
			{
				max = middle - 1;
			}
		}

		return -1;
	}

	public bool duplicates(string word, List<Word> words)   //using indexList finds out if it is duplicate
	{
        if(indexList(word, words) != -1)
            return true;

        return false;
	}
	
	public void insertList(Word word, List<Word> words) //insorts the word so that it will always stay sorted
	{
		words.Add(word);
        sortList(words);
	}
	
	public void merge(List<Word> arr, int left, int middle, int right) 
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
            mergeSort(arr, left, middle);
            mergeSort(arr, middle + 1, right);
            merge(arr, left, middle, right);
        }
	}

    public bool isEndWord(string word) //looks at the last letter to check if it is an end character
    {
        string lastLetter = word.Substring(word.Length - 1);
        if (lastLetter.Contains('.') || lastLetter.Contains('!') || lastLetter.Contains('?'))
            return true;
        return false;
    }

    public void addStringArrayToList(String[] split, List<Word> words)
    {
        insertList(new StartWord(split[0], split[1]), words); //first word must be start word with null as parent

        for (int i = 1; i < split.Length - 1; i++)
        {
            string before = split[i - 1];
            string after = split[i + 1];
            String current = split[i];

            if (duplicates(current, words))  //duplicate, add parent and child
            {
                int index = indexList(current, words);
                words[index].addAfters(after);
                words[index].addBefores(before);
            }
            else    //not a duplicate, add word
            {
                if (isEndWord(current))
                    insertList(new EndWord(current, before, after), words);
                else if (isEndWord(before))
                    insertList(new StartWord(current, after, before), words);
                else
                    insertList(new MiddleWord(current, after, before), words);
            }

        }

        insertList(new EndWord(split[split.Length - 1], split[split.Length - 2]), words); //last word must be start word with null as child
    }


    public void addWordBasedOnString(String name, String[] before, String[] after, List<Word> words)
    {
        if (!duplicates(name, words))
        {
            if(isEndWord(name))
            {
                insertList(new EndWord(name, before[0], after[0]), words);
            }
            else if (isEndWord(before[0]))//if one before is an end word, the overall word is a start word
            {
                insertList(new StartWord(name, before[0], after[0]), words);
            }
            else
            {
                insertList(new MiddleWord(name, before[0], after[0]), words);
            }

            int index = indexList(name, words);

            for(int i = 1; i < before.Length; i++)
            {
                words[index].addBefores(before[i]);
            }
            for (int i = 1; i < after.Length; i++)
            {
                words[index].addAfters(after[i]);
            }
        }
        else
        {
            int index = indexList(name, words);

            for (int i = 0; i < before.Length; i++)
            {
                words[index].addBefores(before[i]);
            }
            for (int i = 0; i < after.Length; i++)
            {
                words[index].addAfters(after[i]);
            }
        }


    }
}