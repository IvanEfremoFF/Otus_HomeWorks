namespace Stack
{
    internal static class StackExtensions
    {
        public static void Merge(this Stack stack1, Stack stack2)
        {
            while (stack2.Top != null)
            {
                stack1.Add(stack2.Top);
                stack2.Pop();
            }
        }
    }
}
