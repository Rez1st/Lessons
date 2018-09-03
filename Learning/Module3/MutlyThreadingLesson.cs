using System;
using System.Threading;
using System.Threading.Tasks;
using LearningCore;

namespace Module3
{
    public class MutlyThreadingLesson : LessonBase
    {
        protected override void Content()
        {
            TaskOne();
        }

        #region TaskOne

        /// <summary>
        ///     Create a task chain of 4 tasks in a row
        ///     that will return one by one 4 names of 4 people
        ///     and print out al of them in the last chained task
        ///     now do it in for loop
        /// </summary>
        public static void TaskOne()
        {
            var taskReturnsInt = Task.Run(() =>
            {
                var rnd = new Random();
                Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} is running");
                Thread.Sleep(1000);
                Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} finished");
                return rnd.Next(1000);
            });

            var next = taskReturnsInt.ContinueWith(x =>
            {
                Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} is running");
                Thread.Sleep(1000);
                Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} finished");
                Console.WriteLine(x.Result * 10);
            });

            TaskOnePractice();
        }

        private static void TaskOnePractice()
        {
            string[] names = { "Sam", "Joe", "Jim", "Bob" };

            var task = Task.Run(() => { return "4 Gyus: "; });
            Task<string> teampTask = null;

            for (var i = 0; i < names.Length; i++)
            {
                if (teampTask != null) task = teampTask;

                var innerI = i;
                teampTask = task.ContinueWith(prevTask =>
                {
                    ShowThreadIdAndAction();
                    var result = prevTask.Result;

                    return result += " " + names[innerI];
                });
            }

            Console.WriteLine(teampTask?.Result);

            Task.WaitAll(teampTask);
        }

        private static void ShowThreadIdAndAction()
        {
            Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} is running");
            Thread.Sleep(1000);
            Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId} finished");
        }

        //task cancel one thread from another thread
        //task wait all threads
        #endregion
        public static void Cocockroach()
        {
            //Написать программу - тараканьи бега, 4 потока которые будут бежать 10 шагов
            //каждый из потоков будет задерживаться на случайное значение Thread.Speep(1000 - 2000);
            //Как только поток сделал ход - отрисовывать на экране его позицию

            //Предлагаю тараканам хранить текущий шаг для отрисовки в консоли
        }

        #region Modlue Clock

        public static void Clock()///************
        {
            // Написать программу - часы которые будут стартовать отсчет с 00:00
            // Самая первая строчка будет отведена под часы которые меняют значение в реальном времени
            // Под часами будет меню которое будет позволять изменить время на заданное в формате ЧЧ : ММ
            // Сделать валидацию которая будет проверять правильный ввод времени
            // После того как пользователь задаст время - поставть его вместо того что было
            // Использовать ООП (Интерфейсы, Инкапсуляцию), Многопоточность

        }
        public static void InnerClock()
        {

        }

        #endregion
    }


}