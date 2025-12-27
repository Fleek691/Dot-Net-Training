using System;

public class HeightCategory
{
    /// <summary>
    /// Function to categorize Height
    /// </summary>
    /// <param name="height"></param>
    public  static void CheckHeight(int height)
    {   
        //if height is less than 150
        if(height<150){
            Console.WriteLine("Dwarf");
        }
        else if(150<height && height < 165)//if height is between 150 and 165
        {
            Console.WriteLine("Average");
        }else if(165<height && height<190)Console.WriteLine("Tall");//if height is between 165 and 190
        else//if height is not among the options
        {    
            Console.WriteLine("Enter valid height");
        }
        
    }
    
}