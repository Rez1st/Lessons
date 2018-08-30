using System;
using System.Collections;
using LearningCore;

namespace Module3
{
    public class CollectionLesson : LessonBase
    {
        protected override void Content()
        {
            Console.WriteLine(LessonName);

            //System.Collections
            //System.Collections.Generics

            #region ArrayList

            ArrayList arrList = new ArrayList();
            arrList.Add("SomeThing");
            arrList.Add(4);

            Console.WriteLine($"We can see items count {arrList.Count}");
            Console.WriteLine($"We can see the capacity{arrList.Capacity}");

            arrList.AddRange(new object[] {"aaa", 2, 'c'}); //We can add range of arrays

            //If we put same type objects we can sort them or do a reverse
            arrList.Sort();
            arrList.Reverse();

            //We can insert value at the specific spot
            arrList.Insert(1, "SomeVal");

            //we can get specific range to new array
            ArrayList arrayList2 = arrList.GetRange(2, 4);

            //we can do foreach
            foreach (var item in arrayList2)
            {
                Console.WriteLine(item);
            }

            //we can remove item
            arrList.RemoveAt(2);
            arrayList2.Remove(4);

            //we can search for index
            arrayList2.Insert(2, "SomeVal");
            Console.WriteLine(arrayList2.IndexOf("SomeVal"));


            #endregion

            #region SortedList



            #endregion

            #region Stack

            Stack stack = new Stack(); //LIFO
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);


            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Press Any Key");
            Console.ReadLine();
            #endregion

            #region Queue

            Queue queue = new Queue(); //FIFO
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            
            //Remove
            Console.WriteLine(queue.Dequeue());
            queue.Peek();

            #endregion
        }
    }
}