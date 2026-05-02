public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // Step 1: Create a new array of doubles with the specified 'length' to hold the results.
        // Step 2: Loop from index 0 to length - 1.
        // Step 3: For each index i, calculate the multiple as number * (i + 1).
        //         - We use (i + 1) because index 0 should hold the 1st multiple (number * 1),
        //           index 1 should hold the 2nd multiple (number * 2), and so on.
        // Step 4: Store each calculated multiple in the array at position i.
        // Step 5: After the loop finishes, return the populated array.

        var multiples = new double[length];
        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // The goal is to take the last 'amount' elements and move them to the front of the list,
        // while everything else shifts to the right.
        //
        // Example: {1, 2, 3, 4, 5, 6, 7, 8, 9} with amount = 3
        //   - The last 3 elements {7, 8, 9} should move to the front.
        //   - The first 6 elements {1, 2, 3, 4, 5, 6} should follow after.
        //   - Final result: {7, 8, 9, 1, 2, 3, 4, 5, 6}
        //
        // Step 1: Extract the last 'amount' elements from the list using GetRange.
        //         - GetRange(startIndex, count) returns a new list with the requested slice.
        //         - The starting index for the tail is (data.Count - amount).
        // Step 2: Remove those last 'amount' elements from the original list using RemoveRange.
        //         - This leaves only the first part of the list intact.
        // Step 3: Insert the extracted tail at the beginning of the list (index 0)
        //         using InsertRange so the order of those elements is preserved.

        var tail = data.GetRange(data.Count - amount, amount);
        data.RemoveRange(data.Count - amount, amount);
        data.InsertRange(0, tail);
    }
}