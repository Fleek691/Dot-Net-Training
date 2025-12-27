using System;
public class LargestOfThree
{
    /// <summary>
    /// Function to check the largest number among 3 digits
    /// </summary>
    /// <param name="nums"></param>
    public static void CheckLargest(int[] nums)
    {
        for(int num = 0; num < nums.Length; num++)
        {
            if(num==0 && nums[num]>nums[num+1] && nums[num] > nums[num + 2])
            {
                System.Console.WriteLine($"{nums[num]} is the largest.");
            }
            else if(num==1 && nums[num]>nums[num-1] && nums[num]> nums[num + 1])
            {
                System.Console.WriteLine($"{nums[num]} is the largest");
            }
            else
            {
                Console.WriteLine($"{nums[2]} is the largest.");
            }
        }
    } 
}