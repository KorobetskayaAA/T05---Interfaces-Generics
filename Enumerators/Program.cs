using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Enumerators
{
    class Week : IEnumerable
    {
        readonly string[] days = { "пн", "вт", "ср", "чт", "пт", "сб", "вс" };

        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }

    class RandomSequence : IEnumerator, IEnumerable
    {
        Random rnd = new Random();
        int length;
        int maxValue;
        int position = 0;

        public RandomSequence(int length, int maxValue)
        {
            this.length = length;
            this.maxValue = maxValue;
        }
        public object Current => rnd.Next(maxValue);

        public bool MoveNext()
        {
            position++;
            return position <= length;
        }

        public void Reset()
        {
            position = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            foreach (var weekday in new Week())
            {
                Console.WriteLine(weekday);
            }

            var randomSeq = new RandomSequence(20, 100);
            foreach (var n in randomSeq) //
            {
                Console.Write(n + " ");
            }

            Console.WriteLine();

            // foreach - синтаксический сахар для while
            randomSeq.Reset();
            while (randomSeq.MoveNext())
            {
                var n = randomSeq.Current;
                Console.Write(n + " ");
            }
        }
    }
}
