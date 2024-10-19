using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    static class Reflector
    {
        delegate void ResearchedClass<T>();
        public static void ReseachClass<T>(T obj)
        {
            var type = obj.GetType();
            var proops = type.GetProperties();

            using (StreamWriter writer = new StreamWriter(type.Name + ".txt", false))
            {
                writer.WriteLineAsync(proops[0].DeclaringType.Assembly.ToString());


                writer.WriteLineAsync("\n___Constructors___");
                foreach (var constructor in type.GetConstructors())
                {
                    writer.WriteLineAsync(constructor.ToString());
                }

                writer.WriteLineAsync("\n___Methods___");
                foreach (var method in type.GetMethods())
                {
                    writer.WriteLineAsync(method.ToString());
                }

                writer.WriteLineAsync("\n___Fields___");
                foreach (var field in type.GetFields())
                {
                    writer.WriteLineAsync(field.ToString());
                }

                writer.WriteLineAsync("\n___Properties___");
                foreach (var property in type.GetProperties())
                {
                    writer.WriteLineAsync(property.ToString());
                }

                writer.WriteLineAsync("\n___Interfaces___");
                foreach (var interf in type.GetInterfaces())
                {
                    writer.WriteLineAsync(interf.ToString());
                }

                writer.WriteLineAsync("\n___Method Parameters___");
                foreach (var method in type.GetMethods())
                {
                    foreach (var param in method.GetParameters())
                    {
                        if (param.Name.GetType() == typeof(System.String))
                            writer.WriteLineAsync(method.ToString());
                    }
                }
            }
        }

        public static T Create<T>() where T : new()
        {
            T ob = new T();
            return ob;
        }
    }

    public class Person
    {
        public string Name { get; }
        public int age;
        public Person(string name)
        {
            Name = name;
        }
        public Person(int age) { }
        public Person()
        {
            Name = "Valentine";
            age = 19;
        }

        public void Walk()
        {
            Console.WriteLine("person walking");
        }
        public void Eat(string food)
        {
            Console.WriteLine($"Person eats {food}");
        }
        public void Sleep()
        {
            Console.WriteLine("Person sleeps");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Valentine");
            Reflector.ReseachClass(person);
            Reflector.Create<Person>();
            string text;
            using (StreamReader reader = new StreamReader("Person.txt"))
            {
                text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
        }
    }
}