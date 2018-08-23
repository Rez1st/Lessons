using System;
using System.Collections.Generic;
using LearningCore;

namespace Module3
{
    public class GenericLesson : LessonBase
    {
        /// <summary>
        /// Theory:
        /// Introduced in C#2.0
        /// Generics allows us to design classes and methods decoupled from data types
        ///
        /// Generic classes are used by collections in Collections.Generic namespace
        /// </summary>
        protected override void Content()
        {
            Console.WriteLine(LessonName);

            //Generic methods
            GenericMethodSample();
            2.Pause();

            //Generic classes
            GenericClassSample();
            2.Pause();

            //Generic Delegate
            GenericDelegateSample();
            2.Pause();
        }


        #region GenericClasses

        private static void GenericClassSample()
        {
            Response<GetMediaContent> response = new Response<GetMediaContent>();
            //response.Body //will have the appropriate type
        }

        #endregion

        #region GenericMethods

        private static void GenericMethodSample()
        {
            //Step1
            Console.WriteLine(AreSame("s1", "s2"));
            Console.WriteLine(AreSame("s1", "s1"));
            //Step2
            Console.WriteLine(AreSame(1, 2));
            Console.WriteLine(AreSame(1, 1));
            //Step3
            Console.WriteLine(AreSame<double>(1.1, 1.1));
            Console.WriteLine(AreSame<double>(1.1, 1.2));
        }

        /// <summary>
        /// Good method but we need to write one method for each datatype
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        private static bool AreSame(string s1, string s2)
        {
            return s1 == s2;
        }

        /// <summary>
        /// now we can compare each type but
        /// compiler will do box\unbox for each value type
        /// and type convertion and you will be able to pass object of different types
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        private static bool AreSame(object o1, object o2)
        {
            return o1 == o2;
        }

        /// <summary>
        /// Type safe can be used for any Type
        /// no box unbox operations
        /// will not let you to use 2 different types
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="operand1"></param>
        /// <param name="operand2"></param>
        /// <returns></returns>
        private static bool AreSame<T>(T operand1, T operand2)
        {
            return operand1.Equals(operand2);
        }


        #endregion

        #region Generic Delgates

        private static void GenericDelegateSample()
        {
            Concatinate<int> concatinateI = AddNumber;
            Console.WriteLine(concatinateI(11, 13));
            Concatinate<string> concatinateS = AddString;
            Console.WriteLine(concatinateS("Hello ", "World"));
        }

        public delegate T Concatinate<T>(T param1, T param2);

        public static int AddNumber(int a, int b)
        {
            return a + b;
        }

        public static string AddString(string a, string b)
        {
            return a + b;
        }
        #endregion
    }

    #region Generic Classes

    public class Response<T> where T : class
    {
        public T Body { get; set; }
        public string Message { get; set; }
    }

    public class GetMediaContent
    {
        /// <summary>
        /// Assume this will be inner class
        /// </summary>
        public List<object> Photos { get; set; }
    }

    public class GetProfileInfo
    {
        public string Name { get; set; }

        public string LastName { get; set; }
    }

    #endregion


}