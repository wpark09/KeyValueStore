using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVStore
{
    struct KeyValue
    {
        public readonly string key;
        public readonly object value;

        public KeyValue(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
    }

    class MyDictionary
    {
        KeyValue[] kvs = new KeyValue[16];
        int storedValues = 0;

        public object this [string key]
        {
            set
            {
                bool found = false;
                for (int i = 0; i < storedValues && !found; i++)
                {
                    if (kvs[i].key == key)
                    {
                        found = true;
                        kvs[i] = new KeyValue(key, value);
                    }
                }

                if(!found)
                {
                    kvs[storedValues ++] = new KeyValue(key, value);

                    if(storedValues>=kvs.Length)
                    {
                        Array.Resize(ref kvs, kvs.Length << 1);
                    }
                }
            }

            get
            {
                for (int i = 0; i < storedValues; i++)
                {
                    if (kvs[i].key == key)
                        return kvs[i].value;
                }

                throw new KeyNotFoundException($"Didn't find \"{key}\" in MyDictionary");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var d = new MyDictionary();
            //try
            //{
            //    Console.WriteLine(d["Cats"]);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
            //d["Cats"] = 42;
            //d["Dogs"] = 17;
            //Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");

            char[] input = new char[4] { 'M', 'S', 'S', 'A'};

            var list = new List<char>(input);
            list.Add('!');
            Console.WriteLine("This is List<char>: ");
            foreach (var character in list)
            {
                Console.Write(character);
            }

            var linkedList = new LinkedList<char>(input);
            linkedList.AddLast('!');
            Console.WriteLine("\n\nThis is LinkedList<char>: ");
            foreach(var character in linkedList)
            {
                Console.Write(character);
            }

            Console.WriteLine("\n\nThis is Queue<char>: ");
            var queue = new Queue<char>(input);
            queue.Enqueue('!');
            foreach (var c in queue)
            {
                Console.Write(c);
            }

            Console.WriteLine("\n\nThis is Stack<char>: ");
            var stack = new Stack<char>(input);
            stack.Push('!');
            for (int i = stack.Count; i>0; --i)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine("\n\nThis is Dictionary<int, char>: ");
            var dictionary = new Dictionary<int, char>();
            for (int i = 0; i < input.Length; ++i)
            {
                dictionary.Add(i, input[i]);
            }
            dictionary.Add(4, '!');
            foreach (var c in dictionary)
            {
                Console.WriteLine($"Key: {c.Key}, Value: {c.Value}");
            }

            Console.WriteLine("\nThis is SortedList<string, char>: ");
            var sortedList = new SortedList<string, char>();
            sortedList.Add("0 Microsoft", 'M');
            sortedList.Add("1 Software", 'S');
            sortedList.Add("2 and", '&');
            sortedList.Add("3 Systems", 'S');
            sortedList.Add("4 Academy", 'A');
            foreach (var c in sortedList)
            {
                Console.WriteLine($"Key: {c.Key}, Value: {c.Value}");
            }

            input[3] = 'S';
            char[] addToInput = new char[3]{'s', 'A', '!'};

            Console.WriteLine("\nThis is HashSet<char>: ");
            HashSet<char> mssa = new HashSet<char>(input);
            HashSet<char> exclamation = new HashSet<char>(addToInput);
            Console.WriteLine($"First hashset has {mssa.Count()} elements " +
                $"and second hashset has {exclamation.Count()} element.");
            mssa.UnionWith(exclamation);
            foreach (var c in mssa)
            {
                Console.Write(c);
            }
            Console.ReadKey();


        }
    }
}
