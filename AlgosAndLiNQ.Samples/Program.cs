
using AlgosAndLiNQ.Samples;
using AlgosAndLiNQ.Samples.LinQ;

void algoExamples()
{

    var numToSort = new int[] { 10, 30, 50, 30, 70, 71, 80, 16, 9 };
    //before sorting
    numToSort.Print();

    Sorting.QuickSort(numToSort).ToArray().Print();

    //serching

    //Console.WriteLine(Search.LinearSearch(numToSort,200));
    //Sorting.SelectionSort(numToSort);
    //Console.WriteLine(Search.BinarySearch(numToSort,71));
    //Console.WriteLine(Search.BinarySearch(numToSort,70));
   // Console.WriteLine(Search.BinarySearch(numToSort, 30));

}

void LinQExamples()
{
    var exp = new GroupByQueryExample();
 exp.GroupByMethod();
    
}

LinQExamples();

//algoExamples();



