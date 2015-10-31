namespace _12.StackImplementation
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();

            stack.Push(8);
            stack.Push(3);
            stack.Push(6);

            Console.WriteLine("stack.Count => {0} ", stack.Count);
            Console.WriteLine("stack.Capacity => {0} ", stack.Capacity);

            stack.Push(5);
            stack.Push(15);

            Console.WriteLine("\nstack.Count => {0} ", stack.Count);
            Console.WriteLine("stack.Capacity => {0} ", stack.Capacity);

            Console.WriteLine("\nGetting elements from the stack:");

            while (stack.Count > 0)
            {
                Console.Write("{0} ", stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
