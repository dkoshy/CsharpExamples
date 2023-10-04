using System.ComponentModel.DataAnnotations;

namespace AlgosAndLiNQ.Samples
{
    public static class Sorting
    {

        public static int[] BubbleSort(int[] nums)
        {
            var len = nums.Length;

            for(int i = 0; i < len-1; i++)
            {
                for(int j = 0; j < len-i-1; j++) 
                {
                    (nums[j], nums[j+1]) = nums[j] > nums[j+1]
                        ? (nums[j+1], nums[j]) 
                        : (nums[j], nums[j+1]);
                }
            }
            return nums;
        }

        public static int[] SelectionSort(int[] nums)
        {
            var len = nums.Length;  
            for (int i = 0;i<len-1; i++)
            {
                var smallat = i;
                for(int j = i+1; j<len; j++)
                {
                    smallat = nums[smallat] < nums[j] ? smallat : j;
                }
                (nums[i] , nums[smallat]) = (nums[smallat] , nums[i]);
            }
            return nums;
        }

        public static int[] InsertionSort(int[] nums)
        {
            var len = nums.Length;
            for (int i = 1; i<len; i++)
            {
                var key = nums[i];
                int j = i-1;
               while(j>=0 && key < nums[j])
                {
                    nums[j+1] = nums[j];
                    j--;
                }
                nums[j+1] = key;
            }
            return nums;
        }

        public static List<int> QuickSort(int[] nums)
        {
            List<int> sortedNums = new List<int>();

           

            var pivotElemntPlacement = (int[] n) =>
            {
                var len = n.Length;
                var pivotelement = n[len-1];
                var pointer = 0;

                for(int i = 0; i< n.Length-1; i++) 
                {
                    if(pivotelement > n[i])
                    {
                        (n[pointer], n[i]) = (n[i], n[pointer]);
                        pointer++;
                    }
                        
                }
                (n[pointer] , n[len-1]) = (n[len-1], n[pointer]);

                sortedNums.AddRange(n[0..(pointer+1)]);
                return n[(pointer+1)..len];
            };


            while (nums.Length > 1)
            {
                nums =  pivotElemntPlacement(nums[..]) ;
            }
            return sortedNums;
        }

        public static void Print(this int[] nums)
        {
            foreach(int n in nums)
            {
                Console.Write($"{n} , ");
            }
            Console.WriteLine();
        }

    }
}
