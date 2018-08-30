using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LearningCore;

namespace Module3
{
    /// <summary>
    /// Theory: 
    /// Reflection is the ability of a managed code to read its own metadata for the purpose of finding assemblies, modules and type information at runtime.
    /// In other words, reflection provides objects that encapsulate assemblies, modules and types.
    /// </summary>
    public class ReflectionLesson : LessonBase
    {
        protected override void Content()
        {
            Console.WriteLine(LessonName);
            //namespace system reflection

            //Invoke methods from other classes
            Methods();
            2.Pause();

            //Iterate Throug Object Properties example
            IterateThrougObjectProperties();
        }

        private void Methods()
        {
            Calc calc = new Calc(); //create instance of an class

            Type calcType = calc.GetType(); //call get type on instance

            MethodInfo method = calcType.GetMethod("Add"); //now we can get method
            var param = new object[] {6, 7};//create params that will be passed to method

            Console.WriteLine(method?.Invoke(calc, param)); // and invoke that on method info
        }

        /// <summary>
        /// Task: Do it with recursion
        /// </summary>
        private void IterateThrougObjectProperties()
        {
            Person p = new Person()
            {
                Age = 21,
                CardInfo = new BankCardInfo(),
                Email = "some@some.com",
                FirstName = "Tim",
                LastName = "R",
                Passowrd = "password1"
            };

            foreach (var prop in p.GetType().GetProperties())
            {
                Console.WriteLine($"PropertyName: {prop.Name}, PropertyType : {prop.PropertyType.Name}, PropertyValue : {prop.GetValue(p)}");
            }

            //Anonymize example
            SecureData.Anonymize(p);
            foreach (var prop in p.GetType().GetProperties())
            {
                Console.WriteLine($"PropertyName: {prop.Name}, PropertyType : {prop.PropertyType.Name}, PropertyValue : {prop.GetValue(p)}");
            }
        }
    }

    public class Calc
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int  Age { get; set; }

        public string Email { get; set; }

        public BankCardInfo CardInfo { get; set; }

        [SecureData]
        public string Passowrd { get; set; }
    }

    public class BankCardInfo
    {
        [SecureData]
        public string Cvv { get; set; }
        [SecureData]
        public string Pin { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
    }

    public class SecureData : Attribute
    {
        private const string StringReplacement = "*";
        /// <summary>
        /// Recursive method that will loop through
        /// all child nodes and internal collections
        /// and search for [Sensitive] attribute
        /// </summary>
        /// <param name="obj">Object to anonymize</param>
        public static void Anonymize(object obj)
        {
            if (obj == null)
            {
                return;
            }

            foreach (var property in obj.GetType().GetProperties())
            {
                //If we meet property with custom attribute equals sensitive - anonymize it and proceed to next property
                if (property.CustomAttributes.Any(x => x.AttributeType == typeof(SecureData)))
                {
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(obj, StringReplacement, null);
                    }
                    else
                    {
                        property.SetValue(obj, null, null);
                    }

                    continue;
                }

                //If its a primitive type we will not go inside to search for child items with sensitive attribute
                if (property.PropertyType.IsPrimitive
                    || property.PropertyType == typeof(string)
                    || property.PropertyType.IsEnum
                    || property.PropertyType == typeof(DateTime))
                {
                    continue;
                }

                //If its a collection or array - of objects itarate through it or go to child class and check its fields
                var propValue = property.GetValue(obj, null);
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    var enumerable = (IEnumerable)propValue;

                    if (enumerable == null)
                    {
                        continue;
                    }

                    foreach (object child in enumerable)
                        Anonymize(child);
                }
                else
                {
                    Anonymize(propValue);
                }
            }
        }

        public static void ScrubData<T>(ICollection<T> objects)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                var prospect = objects.ElementAt(i);
                Anonymize(prospect);
            }
        }
    }
}
