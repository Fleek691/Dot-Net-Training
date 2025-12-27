using System;

/// <summary>
/// Class demonstrating search with goto in nested loops.
/// </summary>
public class SearchWithGoto
{
    /// <summary>
    /// Implements a deep-nested loop search that uses goto to exit all levels instantly upon finding a result.
    /// Searches for a target in a 3D array.
    /// </summary>
    /// <param name="array">The 3D array to search.</param>
    /// <param name="target">The target value.</param>
    /// <returns>True if found, false otherwise.</returns>
    public static bool Search(int[,,] array, int target)
    {
        int x = array.GetLength(0);
        int y = array.GetLength(1);
        int z = array.GetLength(2);
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    if (array[i, j, k] == target)
                    {
                        goto Found;
                    }
                }
            }
        }
        return false;
    Found:
        return true;
    }
}