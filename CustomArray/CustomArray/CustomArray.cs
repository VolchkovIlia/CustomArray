using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomArray
{
    public class CustomArray<TItem>
    {
        private TItem[] items;

        public CustomArray()
        {
            items = new TItem[0];
        }

        public int Length => items.Length;

        public void Add(TItem item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }

        public void Delete(int index)
        {
            if (index < 0 || index >= items.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }

            TItem[] newItems = new TItem[items.Length - 1];

            for (int i = 0, j = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }

                newItems[j++] = items[i];
            }

            items = newItems;
        }

        public TItem FindFirst(Func<TItem, bool> filter)
        {
            return items.FirstOrDefault(filter);
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", items));
        }

        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 >= items.Length || index2 < 0 || index2 >= items.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }

            TItem temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
    }
}
