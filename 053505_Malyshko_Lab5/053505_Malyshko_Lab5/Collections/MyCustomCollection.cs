using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _053505_Malyshko_Lab5.Interfaces;



namespace _053505_Malyshko_Lab5.Collections
{
    class MyCustomCollection<T> : ICustomCollection<T>
    {
        private class Node<T>
        {
            public Node(T item)
            {
                Item = item;
            }
            public T Item { get; set; }
            public Node<T> Next { get; set; }
        }
        Node<T> head;
        Node<T> tail;
        Node<T> cursor;
        int count = 0;
        public void Add(T item)
        {
            Node<T> node = new(item);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            tail.Next = null;
            count++;
        }
        public void Remove(T item)
        {
            Node<T> current = head;
            Node<T> previous = null;
            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                }
                previous = current;
                current = current.Next;
            }
        }
        public int Count { get { return count; } }
        public T this[int index]
        {
            get
            {
                try { 
                    Node<T> current = head;
                    if (index < count && count != 0)
                    {
                        if (index == 0)
                            return head.Item;
                        else if (index == count - 1)
                            return tail.Item;
                        else
                        {
                            for (int i = 0; i < index; i++)
                            {
                                current = current.Next;
                            }
                            return current.Item;
                        }
                    }
                    else
                    {
                        throw new Exception("Вы вышли за предел списка (get)");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return default;
                }
               
            }
            set
            {
                try
                {
                    Node<T> node = new(value);
                    Node<T> current = head;
                    if (index <= count)
                    {
                        if (index == 0)
                        {
                            if (head != null)
                                head = node;
                            else
                                Add(value);
                        }
                        else if (index == count)
                            Add(value);
                        else
                        {
                            for (int i = 0; i < index; i++)
                            {
                                current = current.Next;
                            }
                            current.Item = value;
                        }
                    }
                    else
                    {
                        throw new Exception("Вы вышли за предел списка (set)");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public void PrintItems()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.Item);
                current = current.Next;
            }
        }
        public bool Contains(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (Equals(current.Item,item))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public T Current()
        {
            if (cursor != null)
            {
                return cursor.Item;
            }
            else
            {
                throw new Exception("Курсор на нуле");
            }
        }
        public void Next()
        {
            if (cursor != null && cursor.Next != null)
                cursor = cursor.Next;
            else
            {
                throw new Exception("Курсор на нуле");
            }
        }
        public void Reset()
        {
            if (head != null)
            {
                cursor = head;
            }
            else
            {
                throw new Exception("Список пуст");
            }
        }
        public T RemoveCurrent()
        {
            Node<T> previos = null;
            Node<T> temp = head;
            if (cursor == null)
            {
                throw new Exception("Указатель на нуле");
            }
            while (!temp.Item.Equals(cursor.Item))
            {
                previos = temp;
                temp = temp.Next;
            }
            Node<T> copy = temp;
            cursor = cursor.Next;
            if (previos == null)
                head = head.Next;
            else
            {
                previos.Next = temp.Next;
            }
            --count;
            return copy.Item;
        }
    }
}
