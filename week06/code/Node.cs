public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // PROBLEM 1: Only allow unique values.
        // Original code used `if (value < Data) ... else ...` which would
        // route equal values into the "greater than" branch and add duplicates.
        // We split the else into `else if (value > Data)` so the equal case
        // simply falls through and does nothing.

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (no duplicates allowed in a sorted set)
    }

    public bool Contains(int value)
    {
        // PROBLEM 2: Mirror the structure of Insert, but instead of inserting
        // we check whether the value exists. Three cases:
        //   1. value == Data → found it
        //   2. value <  Data → search the left subtree (if it exists)
        //   3. value >  Data → search the right subtree (if it exists)

        if (value == Data)
        {
            return true;   // Found the value at the current node
        }
        else if (value < Data)
        {
            // Value would be in the left subtree if it exists
            if (Left is null)
                return false;            // No left child means the value isn't here
            return Left.Contains(value); // Recurse into the left subtree
        }
        else // value > Data
        {
            // Value would be in the right subtree if it exists
            if (Right is null)
                return false;             // No right child means the value isn't here
            return Right.Contains(value); // Recurse into the right subtree
        }
    }

    public int GetHeight()
    {
        // PROBLEM 4: The height of any node is 1 + the max of the heights of
        // its two subtrees. A null child contributes a height of 0, so a leaf
        // node returns 1 + max(0, 0) = 1, which matches the spec.

        int leftHeight = 0;
        int rightHeight = 0;

        // Recurse into the left subtree (if any) to get its height
        if (Left is not null)
            leftHeight = Left.GetHeight();

        // Recurse into the right subtree (if any) to get its height
        if (Right is not null)
            rightHeight = Right.GetHeight();

        // Height of this node = 1 + the taller of the two subtrees
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}