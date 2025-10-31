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
        // We'll start with `[1, 2, 3, ..., length]` using `Enumerable.Range`
        // Then we'll multiply each element by `number` using `Select` and a lambda function
        // Voila!
        return [.. Enumerable.Range(1, length).Select(i => number * i)];
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
        // To rotate a list, notice that we can split it in two and rearrange the halves.
        // For the second half, we take the first `data.Count - amount` elements.
        // For the first half, we take the last `amount` elements (skipping the first `data.Count - amount`).
        // Finally, we combine the two parts in the correct order.
        // Voila!

        // Have to collect to list here or we invalidate the enumerator
        var newData = data.Skip(data.Count - amount).Concat(data.Take(data.Count - amount)).ToList();
        // Unfortunately since we're not returning a List and `data` isn't passed by ref, we have to clear and repopulate it
        data.Clear();
        data.AddRange(newData);
    }
}
