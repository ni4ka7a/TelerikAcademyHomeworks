namespace _11.LinkedList
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var myLinkedList = new LinkedList<int>();
            var firstItem = new ListItem<int> { Value = 5 };
            var secondItem = new ListItem<int> { Value = 16 };
            var thirdItem = new ListItem<int> { Value = 9 };
            var fourthItem = new ListItem<int> { Value = 1 };

            myLinkedList.FirstItem = firstItem;
            firstItem.NextItem = secondItem;
            secondItem.NextItem = thirdItem;
            thirdItem.NextItem = fourthItem;

            var currentItem = myLinkedList.FirstItem;

            while (currentItem != null)
            {
                Console.WriteLine(currentItem.Value);

                currentItem = currentItem.NextItem;
            }
        }
    }
}
