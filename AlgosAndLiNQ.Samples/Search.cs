namespace AlgosAndLiNQ.Samples
{
    public static class Search
    {


        public static bool LinearSearch(int[] nums , int key)
        {
            foreach (int i in nums)
            {
                if (i == key) return true;
            }
            return false;
        }

        public static bool BinarySearch(int[] nums , int key)
        {
            var low = 0;
            var high = nums.Length-1;    
            var mid = (low + high)/2;
           while (low<=high)
            {
                if (nums[mid] == key) return true;
                else
                {
                   (low , high) = key < nums[mid] ? (low ,mid-1) : (mid+1 , high);
                }
                mid = (low + high)/2;
            }
           return false;
        }
    }
}
